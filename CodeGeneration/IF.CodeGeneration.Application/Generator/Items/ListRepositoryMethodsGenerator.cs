﻿using IF.CodeGeneration.Application.Generator.List;
using IF.CodeGeneration.Core;
using IF.CodeGeneration.CSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace IF.CodeGeneration.Application.Generator.Items
{
    public class ListRepositoryMethodsGenerator :  ApplicationCodeGenerateItem
    {
        public ListRepositoryMethodsGenerator(ApplicationCodeGeneratorContext context) : base(context)
        {            

            this.FileType = VSFileType.ListRepositorytMethods;
        }

        public override void Execute()
        {
            StringBuilder interfaceMethod = new StringBuilder();

            interfaceMethod.AppendLine($"Task<List<{this.Context.className}Dto>> Get{this.Context.className}();");
            interfaceMethod.AppendLine("");

            IFVsFile vsFile = this.GetVsFile();

            this.Context.fileSystem.FormatCode(interfaceMethod.ToString(), vsFile.FileExtension,vsFile.FileName);

            var repositoryInterfacePath = $@"{this.Context.VsManager.GetProjectPath(vsFile.ProjectName)}\{vsFile.Path}\I{vsFile.FileName}.{vsFile.FileExtension}";

            CodeGenerationHelper.AddCodeToClassBottom(repositoryInterfacePath, interfaceMethod.ToString(), $"Get{ this.Context.className}", new string[] { });


            CSMethod repositoryMethod = new CSMethod($"Get{this.Context.className}", $"List<{this.Context.className}Dto>", "public");
            repositoryMethod.IsAsync = true;

            

            repositoryMethod.Body += $"var data = await this.GetQuery<{this.Context.classType.Name}>()" + Environment.NewLine;
            repositoryMethod.Body += $".Select(x => new {this.Context.className}Dto" + Environment.NewLine;
            repositoryMethod.Body += $"{{" + Environment.NewLine;

            foreach (var property in this.Context.classTree.Childs)
            {
                CSProperty classProperty = GetClassProperty(property.Name.Split('\\')[2]);
                repositoryMethod.Body += $"{classProperty.Name} = x.{classProperty.Name}," + Environment.NewLine;
            }

            repositoryMethod.Body += $"}}).ToListAsync();" + Environment.NewLine;

            repositoryMethod.Body += $"return data;" + Environment.NewLine;

            var repositoryMethodCode = repositoryMethod.GenerateCode().Template;

            this.Context.fileSystem.FormatCode(repositoryMethodCode, vsFile.FileExtension, vsFile.FileName);

            var repositoryPath = $@"{this.Context.VsManager.GetProjectPath(vsFile.ProjectName)}\{vsFile.Path}\{vsFile.FileName}.{vsFile.FileExtension}";

            CodeGenerationHelper.AddCodeToClassBottom(repositoryPath, repositoryMethodCode, $"Get{ this.Context.className}", new string[] { });


        }
    }
}
