using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tourax.Data.Entities;

namespace Tourax.Data.Initializer
{
    public static class DbInitializer
    {
        public static void Initialize(TouraxDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Matieres.Any())
            {
                return;
            }

            var matieres = new List<MatiereEntity>()
            {
                new MatiereEntity
                {
                    IdMatiere=1,
                    LibelleMatiere="Plastique"
                },
                new MatiereEntity
                {
                    IdMatiere=2,
                    LibelleMatiere="Bois"
                },
                new MatiereEntity
                {
                    IdMatiere=3,
                    LibelleMatiere="Métal"
                }
            };

            matieres.ForEach(m =>
            {
                context.Matieres.Add(m);
            });
            context.SaveChanges();


            if (context.Bobines.Any())
            {
                return;
            }

            var bobines = new List<BobineEntity>()
            {
                new BobineEntity
                {
                    Reference="BOB.E160",
                    Nom="E160 (IEC 60624-23)",
                    Consigne=false,
                    Enroulement=true,
                    Trancanage=true,
                    DiametreExt=160,
                    DiametreInt=100,
                    LargeurExt=160,
                    LargeurInt=128,
                    IdMatiere=1,
                    Moyeu=22,
                    PoidsAVide=250,
                    PoidsMaxAutorise=2000,
                    ImageName=null
                },
                new BobineEntity
                {
                    Reference="BOB.B64",
                    Nom="B64",
                    Consigne=true,
                    Enroulement=true,
                    Trancanage=true,
                    DiametreExt=202,
                    DiametreInt=120,
                    LargeurExt=185,
                    LargeurInt=150,
                    IdMatiere=1,
                    Moyeu=75,
                    PoidsAVide=660,
                    PoidsMaxAutorise=5000,
                    ImageName=null
                },
                new BobineEntity
                {
                    Reference="BOB.DIN250",
                    Nom="DIN4639(DIN250 multi trous)",
                    Consigne=false,
                    Enroulement=true,
                    Trancanage=true,
                    DiametreExt=250,
                    DiametreInt=160,
                    LargeurExt=200,
                    LargeurInt=160,
                    IdMatiere=1,
                    Moyeu=65,
                    PoidsAVide=1050,
                    PoidsMaxAutorise=8000,
                    ImageName=null
                }
            };

            bobines.ForEach(b =>
            {
                context.Bobines.Add(b);
            });
            context.SaveChanges();




        }
    }
}
