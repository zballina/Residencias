using System.Data.Entity;
using Residencias.Models;

namespace Residencias
{
    class DatosInicio : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            context.Users.Add(new ApplicationUser
            {
                Id = "9F2A6013-5B18-44B3-A999-2A7FE35A8444",
                Email = "residencias@itsescarcega.edu.mx",
                EmailConfirmed = true,
                UserName = "admin",
                PasswordHash = "AJy8Ro/3RbWuNb9qf40D9g7KL6hHnl4oxy5yHQ0WsI/ETu15+ZMwPxqwo+cy2nYM+w==",
                SecurityStamp = "7090E3FC-DFFA-4504-AFE5-271D65B0A9CF"
            });

            context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole
            {
                Id = "58EF07AF-67FA-410E-ADE0-853E0F10A25A",
                Name = "administrador",
                Users =
                {
                    new Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole
                    {
                        RoleId = "58EF07AF-67FA-410E-ADE0-853E0F10A25A",
                        UserId = "9F2A6013-5B18-44B3-A999-2A7FE35A8444"
                    }
                }
            });
            context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole
            {
                Id = "3B48D680-7EC8-43B5-8AF2-8DD931A06572",
                Name = "docente",
            });
            context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole
            {
                Id = "424A5E58-52C3-4390-BDCF-EFEBA3FF6A0A",
                Name = "asesorinterno",
            });
            context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole
            {
                Id = "5D8F092E-B748-4D4F-B4EC-E9236150C298",
                Name = "asesorexterno",
            });
            context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole
            {
                Id = "A7735BD8-3EE2-439D-8DB8-48007D8D6DF2",
                Name = "revisor",
            });
            context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole
            {
                Id = "7B6C4B11-AEE0-49FB-8959-C7F31FEC16CE",
                Name = "estudiante",
            });
            context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole
            {
                Id = "2EF79A9A-9971-424B-969A-02774A2A6F22",
                Name = "residente",
            });
            context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole
            {
                Id = "DB01CED7-BE45-4E40-A381-622CFBC3BDBC",
                Name = "coordinacion",
            });
            context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole
            {
                Id = "EBAEE88E-B438-4CB9-B35D-FC967A422571",
                Name = "division",
            });
            context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole
            {
                Id = "E0824979-855E-4163-AAE1-FD6CE6131CB2",
                Name = "subdirector",
            });
            context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole
            {
                Id = "2974A767-FDBA-4609-A643-804B9ABA5EF3",
                Name = "desarrolloacademico",
            });
            context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole
            {
                Id = "478429F6-4EBE-4EB6-B81A-E1A9C35BC9B8",
                Name = "serviciosocial",
            });
            context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole
            {
                Id = "EC59C2AE-CB94-4D79-9ABA-FC94B6D5C5A4",
                Name = "presidente",
            });
            context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole
            {
                Id = "28B79382-4664-4CC7-A896-8817729401F8",
                Name = "secretario",
            });
            context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole
            {
                Id = "E5A29215-30A2-4AAB-9C6B-5781FFC70504",
                Name = "vinculacion",
            });
            context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole
            {
                Id = "E47E8955-5A54-4037-9444-9A5802CA7DE8",
                Name = "serviciosescolares",
            });
            base.Seed(context);
        }
    }
}
