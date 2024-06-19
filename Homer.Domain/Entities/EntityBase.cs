using System;

namespace Homer.Domain.Entities
{
    /// <summary>
    /// Entity class object <see cref="Object"/>
    /// </summary>
    public class EntityBase
    {
        private string _name = string.Empty;

        /// <summary>
        /// The entity's number identification.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Entity name.
        /// </summary>
        public string Name { get => _name; set => _name = value; }

        /// <summary>
        /// Guid to save dinamicly.
        /// </summary>
        public Guid Guid { get; set; }
    }
}
