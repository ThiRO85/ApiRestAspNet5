using System.Collections.Generic;

namespace ApiRestAspNet5_01.Hypermedia.Abstract
{
    public interface ISupportsHyperMedia
    {
        List<HyperMediaLink> Links { get; set; }
    }
}
