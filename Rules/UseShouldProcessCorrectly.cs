//
// Copyright (c) Microsoft Corporation.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//

using System;
using System.Linq;
using System.Collections.Generic;
using System.Management.Automation.Language;
using Microsoft.Windows.PowerShell.ScriptAnalyzer.Generic;
#if !CORECLR
using System.ComponentModel.Composition;
#endif
using System.Globalization;

namespace Microsoft.Windows.PowerShell.ScriptAnalyzer.BuiltinRules
{
    /// <summary>
    /// UseShouldProcessCorrectly: Analyzes the ast to check that if the ShouldProcess attribute is present, the function calls ShouldProcess and vice versa.
    /// </summary>
#if !CORECLR
[Export(typeof(IScriptRule))]
#endif
    public class UseShouldProcessCorrectly : IScriptRule
    {
        private Ast ast;
        private string fileName;
        private FunctionReferenceDigraph funcDigraph;

        private List<DiagnosticRecord> diagnosticRecords;

        private readonly Vertex shouldProcessVertex;
        private readonly Vertex shouldContinueVertex;


        public UseShouldProcessCorrectly()
        {
            diagnosticRecords = new List<DiagnosticRecord>();
            shouldContinueVertex = new Vertex {name="ShouldContinue", ast=null};
            shouldProcessVertex = new Vertex {name="ShouldProcess", ast=null};
        }

        /// <summary>
        /// AnalyzeScript: Analyzes the ast to check that if the ShouldProcess attribute is present, the function calls ShouldProcess and vice versa.
        /// </summary>
        /// <param name="ast">The script's ast</param>
        /// <param name="fileName">The script's file name</param>
        /// <returns>A List of diagnostic results of this rule</returns>
        public IEnumerable<DiagnosticRecord> AnalyzeScript(Ast ast, string fileName)
        {
            if (ast == null) throw new ArgumentNullException(Strings.NullAstErrorMessage);

            diagnosticRecords.Clear();
            this.ast = ast;
            this.fileName = fileName;
            funcDigraph = new FunctionReferenceDigraph();
            ast.Visit(funcDigraph);
            FindViolations();
            foreach (var dr in diagnosticRecords)
            {
                yield return dr;
            }

            // yield break;

            // IEnumerable<Ast> funcDefAsts = ast.FindAll(testAst => testAst is FunctionDefinitionAst, true);
            // IEnumerable<Ast> attributeAsts;
            // IEnumerable<Ast> memberAsts;
            // IScriptExtent extent;
            // string funcName;
            // string supportsShouldProcess = "SupportsShouldProcess";
            // string trueString = "$true";
            // bool hasShouldProcessAttribute;
            // bool callsShouldProcess;

            // foreach (FunctionDefinitionAst funcDefAst in funcDefAsts) {
            //     extent = funcDefAst.Extent;
            //     funcName = funcDefAst.Name;

            //     hasShouldProcessAttribute = false;
            //     callsShouldProcess = false;

            //     attributeAsts = funcDefAst.FindAll(testAst => testAst is NamedAttributeArgumentAst, true);
            //     foreach (NamedAttributeArgumentAst attributeAst in attributeAsts) {
            //         hasShouldProcessAttribute |= ((attributeAst.ArgumentName.Equals(supportsShouldProcess, StringComparison.OrdinalIgnoreCase) && attributeAst.Argument.Extent.Text.Equals(trueString, StringComparison.OrdinalIgnoreCase))
            //             // checks for the case if the user just use the attribute without setting it to true
            //             || (attributeAst.ArgumentName.Equals(supportsShouldProcess, StringComparison.OrdinalIgnoreCase) && attributeAst.ExpressionOmitted));
            //     }

            //     memberAsts = funcDefAst.FindAll(testAst => testAst is MemberExpressionAst, true);
            //     foreach (MemberExpressionAst memberAst in memberAsts) {
            //         callsShouldProcess |= memberAst.Member.Extent.Text.Equals("ShouldProcess", StringComparison.OrdinalIgnoreCase) || memberAst.Member.Extent.Text.Equals("ShouldContinue", StringComparison.OrdinalIgnoreCase);
            //     }

            //     if (hasShouldProcessAttribute && !callsShouldProcess) {
            //         yield return new DiagnosticRecord(string.Format(CultureInfo.CurrentCulture, Strings.ShouldProcessErrorHasAttribute, funcName), extent, GetName(), DiagnosticSeverity.Warning, fileName);
            //     }
            //     else if (!hasShouldProcessAttribute && callsShouldProcess) {
            //          yield return new DiagnosticRecord(string.Format(CultureInfo.CurrentCulture, Strings.ShouldProcessErrorHasCmdlet, funcName), extent, GetName(), DiagnosticSeverity.Warning, fileName);
            //     }
            // }
        }

        private void FindViolations()
        {
            foreach (var v in funcDigraph.GetVertices())
            {
                var dr = GetViolation(v);
                if (dr != null)
                {
                    diagnosticRecords.Add(dr);
                }
            }
        }

        /// <summary>
        /// GetName: Retrieves the name of this rule.
        /// </summary>
        /// <returns>The name of this rule</returns>
        public string GetName()
        {
            return string.Format(CultureInfo.CurrentCulture, Strings.NameSpaceFormat, GetSourceName(), Strings.ShouldProcessName);
        }

        /// <summary>
        /// GetCommonName: Retrieves the Common name of this rule.
        /// </summary>
        /// <returns>The common name of this rule</returns>
        public string GetCommonName()
        {
            return string.Format(CultureInfo.CurrentCulture, Strings.ShouldProcessCommonName);
        }

        /// <summary>
        /// GetDescription: Retrieves the description of this rule.
        /// </summary>
        /// <returns>The description of this rule</returns>
        public string GetDescription()
        {
            return string.Format(CultureInfo.CurrentCulture,Strings.ShouldProcessDescription);
        }

        /// <summary>
        /// GetSourceType: Retrieves the type of the rule: builtin, managed or module.
        /// </summary>
        public SourceType GetSourceType()
        {
            return SourceType.Builtin;
        }

        /// <summary>
        /// GetSeverity: Retrieves the severity of the rule: error, warning of information.
        /// </summary>
        /// <returns></returns>
        public RuleSeverity GetSeverity()
        {
            return RuleSeverity.Warning;
        }

        /// <summary>
        /// GetSourceName: Retrieves the module/assembly name the rule is from.
        /// </summary>
        public string GetSourceName()
        {
            return string.Format(CultureInfo.CurrentCulture,Strings.SourceName);
        }

        private DiagnosticRecord GetViolation(Vertex v)
        {
            bool callsShouldProcess = funcDigraph.IsConnected(v, shouldContinueVertex)
                        || funcDigraph.IsConnected(v, shouldProcessVertex);
            FunctionDefinitionAst fast = v.ast as FunctionDefinitionAst;
            if (fast == null)
            {
                return null;
            }

            if (DeclaresSupportsShouldProcess(fast))
            {
                if (!callsShouldProcess)
                {
                    return new DiagnosticRecord(
                        string.Format(
                            CultureInfo.CurrentCulture,
                            Strings.ShouldProcessErrorHasAttribute,
                            fast.Name),
                        ast.Extent,
                        GetName(),
                        DiagnosticSeverity.Warning,
                        ast.Extent.File);
                }
            }
            else
            {
                if (callsShouldProcess)
                {
                    // check if upstream function declares SupportShouldProcess\
                    // if so, this might just be a helper function
                    // do not flag this case
                    if (UpstreamDeclaresShouldProcess(v))
                    {
                        return null;
                    }

                    return new DiagnosticRecord(
                         string.Format(
                             CultureInfo.CurrentCulture,
                             Strings.ShouldProcessErrorHasCmdlet,
                             fast.Name),
                            v.ast.Extent,
                            GetName(),
                            DiagnosticSeverity.Warning,
                            fileName);
                }
            }

            return null;
        }

        private bool UpstreamDeclaresShouldProcess(Vertex v)
        {
            var equalityComparer = new VertexEqualityComparer();
            foreach (var vertex in funcDigraph.GetVertices())
            {
                if (equalityComparer.Equals(vertex, v))
                {
                    continue;
                }

                var fast = vertex.ast as FunctionDefinitionAst;
                if (fast == null)
                {
                    continue;
                }

                if (DeclaresSupportsShouldProcess(fast)
                    && funcDigraph.IsConnected(vertex, v))
                {
                    return true;
                }
            }
            return false;
        }

        private bool DeclaresSupportsShouldProcess(FunctionDefinitionAst ast)
        {
            if (ast.Body.ParamBlock == null)
            {
                return false;
            }

            foreach (var attr in ast.Body.ParamBlock.Attributes)
            {
                if (attr.NamedArguments == null)
                {
                    continue;
                }

                foreach (var namedArg in attr.NamedArguments)
                {
                    if (namedArg.ArgumentName.Equals(
                        "SupportsShouldProcess",
                        StringComparison.OrdinalIgnoreCase))
                    {
                        var argAst = namedArg.Argument as VariableExpressionAst;
                        if (argAst != null)
                        {
                            if (argAst.VariablePath.UserPath.Equals("true", StringComparison.OrdinalIgnoreCase))
                            {
                                return true;
                            }
                        }
                        else
                        {
                            return namedArg.ExpressionOmitted;
                        }
                    }
                }
            }

            return false;
        }
    }

    class Vertex
    {
        public string name;
        public Ast ast;
        public override string ToString()
        {
            return name;
        }
    }

    class VertexEqualityComparer : IEqualityComparer<Vertex>
    {
        public bool Equals(Vertex x, Vertex y)
        {
            if (x == null && y == null)
            {
                return true;
            }
            else if (x == null || y == null)
            {
                return false;
            }
            else if (x.name.Equals(y.name, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetHashCode(Vertex obj)
        {
            return obj.name.GetHashCode();
        }
    }



    class FunctionReferenceDigraph : AstVisitor
    {
        private Digraph<Vertex> digraph;

        private Stack<Vertex> functionVisitStack;
        private bool IsWithinFunctionDefinition()
        {
            return functionVisitStack.Count > 0;
        }

        private Vertex GetCurrentFunctionContext()
        {
            return functionVisitStack.Peek();
        }

        public Digraph<Vertex> GetDigraph()
        {
            return digraph;
        }
        public FunctionReferenceDigraph()
        {
            digraph = new Digraph<Vertex>(new VertexEqualityComparer());
            functionVisitStack = new Stack<Vertex>();
        }

        public override AstVisitAction VisitCommand(CommandAst ast)
        {
            if (ast == null)
            {
                return AstVisitAction.SkipChildren;
            }

            var cmdName = ast.GetCommandName();
            var vertex = new Vertex {name = cmdName, ast = ast};
            AddVertex(vertex);
            if (IsWithinFunctionDefinition())
            {
                AddEdge(GetCurrentFunctionContext(), vertex);
            }
            return AstVisitAction.Continue;
        }

        public void AddVertex(Vertex name)
        {
            if (!digraph.ContainsVertex(name))
            {
                digraph.AddVertex(name);
            }
        }

        public void AddEdge(Vertex fromV, Vertex toV)
        {
            if (!digraph.GetNeighbors(fromV).Contains(toV, new VertexEqualityComparer()))
            {
                digraph.AddEdge(fromV, toV);
            }
        }

        public override AstVisitAction VisitFunctionDefinition(FunctionDefinitionAst ast)
        {
            if (ast == null)
            {
                return AstVisitAction.SkipChildren;
            }

            var functionVertex = new Vertex {name=ast.Name, ast=ast};
            functionVisitStack.Push(functionVertex);
            AddVertex(functionVertex);
            ast.Body.Visit(this);
            functionVisitStack.Pop();
            return AstVisitAction.SkipChildren;
        }

        public override AstVisitAction VisitInvokeMemberExpression(InvokeMemberExpressionAst ast)
        {
            if (ast == null)
            {
                return AstVisitAction.SkipChildren;
            }

            var expr = ast.Expression.Extent.Text;
            var memberExprAst = ast.Member as StringConstantExpressionAst;
            if (memberExprAst == null)
            {
                return AstVisitAction.Continue;
            }

            var member = memberExprAst.Value;
            if (string.IsNullOrWhiteSpace(member))
            {
                return AstVisitAction.Continue;
            }

            var exprVertex = new Vertex {name=expr, ast=ast.Expression};
            var memberVertex = new Vertex {name=memberExprAst.Value, ast=memberExprAst};
            AddVertex(exprVertex);
            AddVertex(memberVertex);
            AddEdge(exprVertex, memberVertex);
            if (IsWithinFunctionDefinition())
            {
                AddEdge(GetCurrentFunctionContext(), exprVertex);
            }

            return AstVisitAction.Continue;
        }

        public IEnumerable<Vertex> GetVertices()
        {
            return digraph.GetVertices();
        }

        internal bool IsConnected(Vertex vertex, Vertex shouldVertex)
        {
            if (digraph.ContainsVertex(vertex)
                && digraph.ContainsVertex(shouldVertex))
            {
                return digraph.IsConnected(vertex, shouldVertex);
            }
            return false;
        }
    }
}




