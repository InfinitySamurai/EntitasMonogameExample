﻿using System;
using System.Linq;
using System.Reflection;
using Entitas;
using Entitas.CodeGenerator;

namespace Tester {

    public static class CodeGenerator {

        public static void Generate() {

            Console.WriteLine("Generating code...");

            // All code generators that should be used
            var codeGenerators = new ICodeGenerator[] {
                new ComponentIndicesGenerator(),
                new ComponentExtensionsGenerator(),
                new PoolAttributesGenerator(),
                new PoolsGenerator(),
                new BlueprintsGenerator()
            };

            // Specify all pools
            var poolNames = new[] { "Core", "Meta", "enemies" };

            // Specify all blueprints
            var blueprintNames = new string[0];

            generate(
                codeGenerators,
                poolNames,
                blueprintNames,
                "../../../../Tester/Generated/"
            );
        }

        static void generate(ICodeGenerator[] codeGenerators,
                             string[] poolNames,
                             string[] blueprintNames,
                             string path) {

            var assembly = Assembly.GetAssembly(typeof(Entity));
            var provider = new TypeReflectionProvider(assembly.GetTypes(), poolNames, blueprintNames);

            var generatedFiles = Entitas.CodeGenerator.CodeGenerator.Generate(provider, path, codeGenerators);

            foreach(var file in generatedFiles) {
                Console.WriteLine(file.generatorName + ": " + file.fileName);
            }

            var totalGeneratedFiles = generatedFiles.Select(file => file.fileName).Distinct().Count();

            Console.WriteLine("");
            Console.WriteLine("Generated " + totalGeneratedFiles + " files.");
            Console.Read();
        }
    }
}
