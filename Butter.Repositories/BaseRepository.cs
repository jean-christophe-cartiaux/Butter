using Butter.DataAcces;
using Butter.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butter.Repositories
{/// <summary>
/// Classe de base pour les actions sur EF Core
/// implémentant l'interface  générique <seealso cref="IRepo{T, U}"/>
/// </summary>
/// <typeparam name="T">Le Type D'entité</typeparam>
/// <typeparam name="U">Le Type de la pk dans la DB</typeparam>
    public class BaseRepository<T, U> : IRepo<T, U>
        where T : class
    { 
        /// <summary>
        /// Permet de récupérer tout les enregistrement dans la DB
        /// </summary>
        /// <returns>un <see cref="IEnumerable{T}"/> Contenant les données</returns>
        public IEnumerable<T> Get()
        {
            //! 1 j'aibesoin de mon context
            ButterContext _ctx = new ButterContext();
            //! 2 Récupérer la collection de données

            return _ctx.Set<T>().AsEnumerable<T>();
          
        }

        /// <summary>
        /// Permet de récupérer 1 enregistrement basé sur sa clé
        /// </summary>
        /// <param name="id">l'identifiant de l'enregistrement recherché</param>
        /// <returns> une instance de T ou NULL</returns>
        public T GetById(U id)
        {
            //! 1 j'aibesoin de mon context
            ButterContext _ctx = new ButterContext();
            //! 2 Récupérer la collection de données

            return _ctx.Set<T>().Find(id);
        }
        /// <summary>
        /// Permet d'ajouter une entité dans notre db
        /// </summary>
        /// <param name="item"> L'entité a ajouter</param>

        public void Add(T item)
        {
            //! 1 j'aibesoin de mon context
            ButterContext _ctx = new ButterContext();
            //! 2 Ajouter mon item dans le DbSet Correspondant
            
            _ctx.Set<T>().Add(item);
            //!3 Save
            _ctx.SaveChanges();
        }
        /// <summary>
        /// permet de supprimer un enregistrement basé sur l'identifiant
        /// </summary>
        /// <param name="id">l'identifiant de l'élément a supprimer</param>

        public void Delete(U id)
        {
            //! 1 j'aibesoin de mon context
            ButterContext _ctx = new ButterContext();
            //! 1.1 Retrouver l'item Correspondant
            T item = _ctx.Set<T>().Find(id);
            //! 2 Ajouter mon item dans le DbSet Correspondant

            _ctx.Set<T>().Remove(item);
            //!3 Save
            _ctx.SaveChanges();
        }
        /// <summary>
        /// Permet de mettre a jour une entité 
        /// </summary>
        /// <param name="item">L'entité a mettre a jour </param>

        public void Update(T item)
        {
            //! 1 j'aibesoin de mon context
            ButterContext _ctx = new ButterContext();
            //! 2 MAJ mon item dans le DbSet Correspondant

            _ctx.Set<T>().Update(item);
            //!3 Save
            _ctx.SaveChanges();
        }
    }
}
