using RecTracPom;
using System.Threading;

namespace RecTracActions
{
    public interface IManagementActor
    {
        void Navigate();
        void Add(string code);

        void Delete(string code);

        void Delete();
        
        bool IsExists(string code);

        void Clone(string code);

        bool IsClonable { get; }
    }
}
