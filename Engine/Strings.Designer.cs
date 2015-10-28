﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.Windows.PowerShell.ScriptAnalyzer {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Strings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Strings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Microsoft.Windows.PowerShell.ScriptAnalyzer.Strings", typeof(Strings).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Checking assembly file &apos;{0}&apos; ....
        /// </summary>
        internal static string CheckAssemblyFile {
            get {
                return ResourceManager.GetString("CheckAssemblyFile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Checking module &apos;{0}&apos; ....
        /// </summary>
        internal static string CheckModuleName {
            get {
                return ResourceManager.GetString("CheckModuleName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CommandInfo not found for function: {0}.
        /// </summary>
        internal static string CommandInfoNotFound {
            get {
                return ResourceManager.GetString("CommandInfoNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Writes all diagnostics to WriteObject..
        /// </summary>
        internal static string DefaultLoggerDescription {
            get {
                return ResourceManager.GetString("DefaultLoggerDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to WriteObjects.
        /// </summary>
        internal static string DefaultLoggerName {
            get {
                return ResourceManager.GetString("DefaultLoggerName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot find file &apos;{0}&apos;..
        /// </summary>
        internal static string FileNotFound {
            get {
                return ResourceManager.GetString("FileNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot find the path &apos;{0}&apos;..
        /// </summary>
        internal static string InvalidPath {
            get {
                return ResourceManager.GetString("InvalidPath", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Profile file &apos;{0}&apos; is invalid because it does not contain a hashtable..
        /// </summary>
        internal static string InvalidProfile {
            get {
                return ResourceManager.GetString("InvalidProfile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No loggers found..
        /// </summary>
        internal static string LoggersNotFound {
            get {
                return ResourceManager.GetString("LoggersNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot find rule extension &apos;{0}&apos;..
        /// </summary>
        internal static string MissingRuleExtension {
            get {
                return ResourceManager.GetString("MissingRuleExtension", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} cannot be set by both positional and named arguments..
        /// </summary>
        internal static string NamedAndPositionalArgumentsConflictError {
            get {
                return ResourceManager.GetString("NamedAndPositionalArgumentsConflictError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Named arguments must always come after positional arguments..
        /// </summary>
        internal static string NamedArgumentsBeforePositionalError {
            get {
                return ResourceManager.GetString("NamedArgumentsBeforePositionalError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to RuleName must not be null..
        /// </summary>
        internal static string NullRuleNameError {
            get {
                return ResourceManager.GetString("NullRuleNameError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Parse error in file {0}:  {1} at line {2} column {3}..
        /// </summary>
        internal static string ParserErrorFormat {
            get {
                return ResourceManager.GetString("ParserErrorFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There are too many parser errors in {0}. Please correct them before running ScriptAnalyzer..
        /// </summary>
        internal static string ParserErrorMessage {
            get {
                return ResourceManager.GetString("ParserErrorMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to RULE_ERROR.
        /// </summary>
        internal static string RuleErrorMessage {
            get {
                return ResourceManager.GetString("RuleErrorMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot find analyzer rules..
        /// </summary>
        internal static string RulesNotFound {
            get {
                return ResourceManager.GetString("RulesNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Suppression Message Attribute error at line {0} in {1} : {2}.
        /// </summary>
        internal static string RuleSuppressionErrorFormat {
            get {
                return ResourceManager.GetString("RuleSuppressionErrorFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot find any DiagnosticRecord with the Rule Suppression ID {0}..
        /// </summary>
        internal static string RuleSuppressionIDError {
            get {
                return ResourceManager.GetString("RuleSuppressionIDError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Rule {0} cannot be found..
        /// </summary>
        internal static string RuleSuppressionRuleNameNotFound {
            get {
                return ResourceManager.GetString("RuleSuppressionRuleNameNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to All the arguments of the Suppress Message Attribute should be string constants..
        /// </summary>
        internal static string StringConstantArgumentsSuppressionAttributeError {
            get {
                return ResourceManager.GetString("StringConstantArgumentsSuppressionAttributeError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot find any Targets {0} that match the Scope {1} to apply the SuppressMessageAttribute..
        /// </summary>
        internal static string TargetCannotBeFoundError {
            get {
                return ResourceManager.GetString("TargetCannotBeFoundError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to If Target is specified, Scope must be specified..
        /// </summary>
        internal static string TargetWithoutScopeSuppressionAttributeError {
            get {
                return ResourceManager.GetString("TargetWithoutScopeSuppressionAttributeError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Analyzing file: {0}.
        /// </summary>
        internal static string VerboseFileMessage {
            get {
                return ResourceManager.GetString("VerboseFileMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Running {0} rule..
        /// </summary>
        internal static string VerboseRunningMessage {
            get {
                return ResourceManager.GetString("VerboseRunningMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} is not a valid key in the profile hashtable: line {0} column {1} in file {2}.
        /// </summary>
        internal static string WrongKey {
            get {
                return ResourceManager.GetString("WrongKey", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Key in the profile hashtable should be a string: line {0} column {1} in file {2}.
        /// </summary>
        internal static string WrongKeyFormat {
            get {
                return ResourceManager.GetString("WrongKeyFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Scope can only be either function or class..
        /// </summary>
        internal static string WrongScopeArgumentSuppressionAttributeError {
            get {
                return ResourceManager.GetString("WrongScopeArgumentSuppressionAttributeError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Value in the profile hashtable should be a string or an array of strings: line {0} column {1} in file {2}.
        /// </summary>
        internal static string WrongValueFormat {
            get {
                return ResourceManager.GetString("WrongValueFormat", resourceCulture);
            }
        }
    }
}
