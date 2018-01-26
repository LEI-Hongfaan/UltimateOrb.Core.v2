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
                    var rm = new ReaderParameters();
                    rm.InMemory = true;
                    var assembly = AssemblyDefinition.ReadAssembly(fileName_Original, rm);
                    var module = assembly.MainModule;
                    var modified = 0;
                    {
                        var typeref = module.GetType(@"UltimateOrb.Utilities.SizeOfModule", false);
                        if (typeref is TypeDefinition type) {
                            var collection = type.Methods;
                            foreach (var method in collection) {
                                if (@"SizeOf" != method.Name) {
                                    continue;
                                }
                                var tp = method.GenericParameters?[0];
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
                                        ilg.Append(ilg.Create(OpCodes.Sizeof, tp));
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
                    var wp = new WriterParameters() { };
                    assembly.Write(fileName_Modified, wp);
                    Console.Out.WriteLine($@"Done.");
                    File.Replace(fileName_Modified, fileName_Original, fileName_Backup);
                    Console.Out.WriteLine($@"""{fileName_Original}"" -> ""{fileName_Backup}""");
                    Console.Out.WriteLine($@"""{fileName_Modified}"" -> ""{fileName_Original}""");
                    Console.Out.WriteLine(@"Done.");
                    return (int)ExitStatus.OK;
                } catch (Exception) {
                    return (int)ExitStatus.RequestFailed;
                }
                break;
            }
            return (int)ExitStatus.UserCanceled;
        }
    }
}
