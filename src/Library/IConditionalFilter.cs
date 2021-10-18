using System;

namespace CompAndDel
{
    /// <summary>
    /// Un filtro que recibe, procesa y retorna imágenes. El filtro puede retornar la misma imagen o una nueva imagen
    /// creada por él.
    /// </remarks>
    public interface IConditionalFilter : IFilter
    {
        bool Result { get; }
    }
}
