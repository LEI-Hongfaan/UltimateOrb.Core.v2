using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.IO;
using System.Linq;

namespace ThisAssembly {

    public static class Program {

        public enum ExitStatus {
            OK,
            UserCanceled,
            RequestFailed
        }

        public static int Main(string[] args) {




            for (; null != args;) {
                try {
                    var fileName = args?[0];
                    if (null == fileName) {
                        return (int)ExitStatus.UserCanceled;
                    }
                    var dirName = Path.GetDirectoryName(fileName);
                    var fileNameShort = Path.GetFileNameWithoutExtension(fileName);
                    var fileNameExt = Path.GetExtension(fileName);

                    var fileName_Original = Path.Combine(dirName, fileNameShort + fileNameExt);
                    var fileName_Modified = Path.Combine(dirName, fileNameShort + @".tmp");
                    var fileName_Backup = Path.Combine(dirName, fileNameShort + @".bak");
                    var fullpath = Path.GetFullPath(fileName_Original);
                    var rm = new ReaderParameters() { ThrowIfSymbolsAreNotMatching = true, ReadSymbols = true };
                    rm.InMemory = true;
                    var assembly = AssemblyDefinition.ReadAssembly(fileName_Original, rm);
                    var module = assembly.MainModule;
                    var modified = 0;
                    {
                        var sdfsdaf = typeof(OpCodes).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
                        var sdafsd = sdfsdaf.ToDictionary(x => x.Name.ToUpperInvariant());
                        sdafsd.Add("Ldelem".ToUpperInvariant(), typeof(OpCodes).GetField(nameof(OpCodes.Ldelem_Any), System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static));
                        sdafsd.Add("Stelem".ToUpperInvariant(), typeof(OpCodes).GetField(nameof(OpCodes.Stelem_Any), System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static));

                        foreach (var typeref in module.GetTypes()) {
                            if (typeref is TypeDefinition type) {
                                foreach (var method in type.Methods) {
                                    if (!method.HasCustomAttributes) {
                                        continue;
                                    }
                                    var sdafds = default(string);

                                    var sdfsdf = default(CustomAttribute);
                                    foreach (var customAttribute in method.CustomAttributes) {

                                        if ("ILMethodBodyAttribute" == customAttribute.AttributeType.Name) {

                                            var aaa = customAttribute.ConstructorArguments[0];

                                            sdafds = aaa.Value as string;
                                            sdfsdf = customAttribute;
                                            break;
                                        }
                                    }

                                    if (null == sdafds) {
                                        continue;
                                    }


                                    using (var sdfsdfas = new StringReader(sdafds)) {

                                        var ts = method.GenericParameters;
                                        if (!method.HasBody) {
                                            continue;
                                        }
                                        {
                                            var bd = method.Body;
                                            var ins = bd.Instructions;
                                            var ilg = (ILProcessor)null;
                                            ilg = bd.GetILProcessor();
                                            var insa = ins.ToArray();
                                            for (var i = 0; insa.Length > i; ++i) {
                                                ilg.Remove(insa[i]);
                                            }
                                            {
                                                string sdfdasff;
                                                for (; null != (sdfdasff = sdfsdfas.ReadLine());) {
                                                    Console.Out.WriteLine($@"method {method.Name}");
                                                    Console.Out.WriteLine($@"  ""{sdfdasff}""");
                                                    var sdfasd = sdfdasff.Split(new[] { ' ', '\t', }, StringSplitOptions.RemoveEmptyEntries);
                                                    Console.Out.WriteLine("ddddd");
                                                    var sdfas = sdfasd.FirstOrDefault();
                                                    if (null == sdfas) {
                                                        continue;
                                                    }
                                                    var sdfa = sdfas.Replace('.', '_').ToUpperInvariant();
                                                    var safsad = sdafsd[sdfa];
                                                    var sdfsaf = (safsad.GetValue(null) as OpCode?);
                                                    if (null == sdfsaf) {
                                                        throw new Exception("gfghgh");
                                                    }
                                                    var sdfdsa = sdfsaf.Value;
                                                    switch (sdfdsa.OperandType) {
                                                    case OperandType.InlineBrTarget:
                                                        throw new NotImplementedException();
                                                        break;
                                                    case OperandType.InlineField:
                                                        throw new NotImplementedException();
                                                        break;
                                                    case OperandType.InlineI:
                                                        throw new NotImplementedException();
                                                        break;
                                                    case OperandType.InlineI8:
                                                        throw new NotImplementedException();
                                                        break;
                                                    case OperandType.InlineMethod:
                                                        throw new NotImplementedException();
                                                        break;
                                                    case OperandType.InlineNone:
                                                        ilg.Append(ilg.Create(sdfdsa));
                                                        break;
                                                    case OperandType.InlinePhi:
                                                        throw new NotImplementedException();
                                                        break;
                                                    case OperandType.InlineR:
                                                        throw new NotImplementedException();
                                                        break;
                                                    case OperandType.InlineSig:
                                                        throw new NotImplementedException();
                                                        break;
                                                    case OperandType.InlineString:
                                                        throw new NotImplementedException();
                                                        break;
                                                    case OperandType.InlineSwitch:
                                                        throw new NotImplementedException();
                                                        break;
                                                    case OperandType.InlineTok:
                                                        throw new NotImplementedException();
                                                        break;
                                                    case OperandType.InlineType:
                                                        ilg.Append(ilg.Create(sdfdsa, ts[int.Parse(sdfasd[1].Substring(2))]));
                                                        break;
                                                    case OperandType.InlineVar:
                                                        throw new NotImplementedException();
                                                        break;
                                                    case OperandType.InlineArg:
                                                        throw new NotImplementedException();
                                                        break;
                                                    case OperandType.ShortInlineBrTarget:
                                                        throw new NotImplementedException();
                                                        break;
                                                    case OperandType.ShortInlineI:
                                                        throw new NotImplementedException();
                                                        break;
                                                    case OperandType.ShortInlineR:
                                                        throw new NotImplementedException();
                                                        break;
                                                    case OperandType.ShortInlineVar:
                                                        throw new NotImplementedException();
                                                        break;
                                                    case OperandType.ShortInlineArg:
                                                        throw new NotImplementedException();
                                                        break;
                                                    default:
                                                        throw new Exception("il opcode arg");
                                                    }



                                                }
                                            }
                                            method.CustomAttributes.Remove(sdfsdf);

                                            ++modified;
                                            if (null != ilg) {
                                                var ignored = 0;
                                            }
                                        }



                                    }

                                }
                            }
                        }

                    }
                    {
                        
                        if (false) {
                            var typeref = module.GetType(@"UltimateOrb.Utilities.BooleanIntegerModule", false);
                            if (typeref is TypeDefinition type) {
                                var collection = type.Methods;
                                foreach (var method in collection) {
                                    if (@"LessThan" != method.Name) {
                                        continue;
                                    }
                                    if (!method.HasBody) {
                                        continue;
                                    }
                                    {
                                        var bd = method.Body;
                                        var f = method.Parameters[0].ParameterType.Name;
                                        var s = method.Parameters[1].ParameterType.Name;
                                        if (f != s) {
                                            continue;
                                        }
                                        var ins = bd.Instructions;
                                        var ilg = (ILProcessor)null;
                                        ilg = bd.GetILProcessor();
                                        var insa = ins.ToArray();
                                        for (var i = 0; insa.Length > i; ++i) {
                                            ilg.Remove(insa[i]);
                                        }
                                        {
                                            ilg.Append(ilg.Create(OpCodes.Ldarg_0));
                                            ilg.Append(ilg.Create(OpCodes.Ldarg_1));
                                            if (f.ToUpperInvariant().StartsWith("U")) {
                                                ilg.Append(ilg.Create(OpCodes.Clt_Un));
                                            } else {
                                                ilg.Append(ilg.Create(OpCodes.Clt));
                                            }
                                            ilg.Append(ilg.Create(OpCodes.Ret));
                                            ++modified;
                                        }
                                        if (null != ilg) {
                                            var ignored = 0;
                                        }
                                    }
                                }
                            }
                        }
                        if (false) {
                            var typeref = module.GetType(@"UltimateOrb.Utilities.BooleanIntegerModule", false);
                            if (typeref is TypeDefinition type) {
                                var collection = type.Methods;
                                foreach (var method in collection) {
                                    if (@"LessThanOrEqual" != method.Name) {
                                        continue;
                                    }
                                    if (!method.HasBody) {
                                        continue;
                                    }
                                    {
                                        var bd = method.Body;
                                        var f = method.Parameters[0].ParameterType.Name;
                                        var s = method.Parameters[1].ParameterType.Name;
                                        if (f != s) {
                                            continue;
                                        }
                                        var ins = bd.Instructions;
                                        var ilg = (ILProcessor)null;
                                        ilg = bd.GetILProcessor();
                                        var insa = ins.ToArray();
                                        for (var i = 0; insa.Length > i; ++i) {
                                            ilg.Remove(insa[i]);
                                        }
                                        {
                                            ilg.Append(ilg.Create(OpCodes.Ldarg_0));
                                            ilg.Append(ilg.Create(OpCodes.Ldarg_1));
                                            if (f.ToUpperInvariant().StartsWith("U") || f == "Single" || f == "Double" || f == "float" || f == "double") {
                                                ilg.Append(ilg.Create(OpCodes.Cgt_Un));
                                            } else {
                                                ilg.Append(ilg.Create(OpCodes.Cgt));
                                            }
                                            ilg.Append(ilg.Create(OpCodes.Ldc_I4_0));
                                            ilg.Append(ilg.Create(OpCodes.Ceq));
                                            ilg.Append(ilg.Create(OpCodes.Ret));
                                            ++modified;
                                        }
                                        if (null != ilg) {
                                            var ignored = 0;
                                        }
                                    }
                                }
                            }
                        }
                        if (false) {
                            var typeref = module.GetType(@"UltimateOrb.Utilities.BooleanIntegerModule", false);
                            if (typeref is TypeDefinition type) {
                                var collection = type.Methods;
                                foreach (var method in collection) {
                                    if (@"GreaterThan" != method.Name) {
                                        continue;
                                    }
                                    if (!method.HasBody) {
                                        continue;
                                    }
                                    {
                                        var bd = method.Body;
                                        var f = method.Parameters[0].ParameterType.Name;
                                        var s = method.Parameters[1].ParameterType.Name;
                                        if (f != s) {
                                            continue;
                                        }
                                        var ins = bd.Instructions;
                                        var ilg = (ILProcessor)null;
                                        ilg = bd.GetILProcessor();
                                        var insa = ins.ToArray();
                                        for (var i = 0; insa.Length > i; ++i) {
                                            ilg.Remove(insa[i]);
                                        }
                                        {
                                            ilg.Append(ilg.Create(OpCodes.Ldarg_0));
                                            ilg.Append(ilg.Create(OpCodes.Ldarg_1));
                                            if (f.ToUpperInvariant().StartsWith("U")) {
                                                ilg.Append(ilg.Create(OpCodes.Cgt_Un));
                                            } else {
                                                ilg.Append(ilg.Create(OpCodes.Cgt));
                                            }
                                            ilg.Append(ilg.Create(OpCodes.Ret));
                                            ++modified;
                                        }
                                        if (null != ilg) {
                                            var ignored = 0;
                                        }
                                    }
                                }
                            }
                        }
                        if (false) {
                            var typeref = module.GetType(@"UltimateOrb.Utilities.BooleanIntegerModule", false);
                            if (typeref is TypeDefinition type) {
                                var collection = type.Methods;
                                foreach (var method in collection) {
                                    if (@"GreaterThanOrEqual" != method.Name) {
                                        continue;
                                    }
                                    if (!method.HasBody) {
                                        continue;
                                    }
                                    {
                                        var bd = method.Body;
                                        var f = method.Parameters[0].ParameterType.Name;
                                        var s = method.Parameters[1].ParameterType.Name;
                                        if (f != s) {
                                            continue;
                                        }
                                        var ins = bd.Instructions;
                                        var ilg = (ILProcessor)null;
                                        ilg = bd.GetILProcessor();
                                        var insa = ins.ToArray();
                                        for (var i = 0; insa.Length > i; ++i) {
                                            ilg.Remove(insa[i]);
                                        }
                                        {
                                            ilg.Append(ilg.Create(OpCodes.Ldarg_0));
                                            ilg.Append(ilg.Create(OpCodes.Ldarg_1));
                                            if (f.ToUpperInvariant().StartsWith("U") || f == "Single" || f == "Double" || f == "float" || f == "double") {
                                                ilg.Append(ilg.Create(OpCodes.Clt_Un));
                                            } else {
                                                ilg.Append(ilg.Create(OpCodes.Clt));
                                            }
                                            ilg.Append(ilg.Create(OpCodes.Ldc_I4_0));
                                            ilg.Append(ilg.Create(OpCodes.Ceq));
                                            ilg.Append(ilg.Create(OpCodes.Ret));
                                            ++modified;
                                        }
                                        if (null != ilg) {
                                            var ignored = 0;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (modified <= 0) {
                        return (int)ExitStatus.RequestFailed;
                    }
                    Console.Out.WriteLine($@"Modified: {modified}.");
                    var sss = (System.Reflection.StrongNameKeyPair)null;
                    try {
                        var keyfile = args?[1];
                        if (null != keyfile) {
                            sss = new System.Reflection.StrongNameKeyPair(File.ReadAllBytes(keyfile));
                        }
                    } catch (Exception) {
                    }

                    Console.Out.Write($@"Writing file: {fileName_Modified}... ");
                    var wp = new WriterParameters() { WriteSymbols = true };
                    assembly.Write(fileName_Modified, wp);
                    Console.Out.WriteLine($@"Done.");
                    File.Replace(fileName_Modified, fileName_Original, fileName_Backup);
                    Console.Out.WriteLine($@"""{fileName_Original}"" -> ""{fileName_Backup}""");
                    Console.Out.WriteLine($@"""{fileName_Modified}"" -> ""{fileName_Original}""");
                    Console.Out.WriteLine(@"Done.");
                    return (int)ExitStatus.OK;
                } catch (Exception ex) {
                    Console.Error.WriteLine(ex);
                    return (int)ExitStatus.RequestFailed;
                }
                break;
            }
            return (int)ExitStatus.UserCanceled;
        }
    }
}
