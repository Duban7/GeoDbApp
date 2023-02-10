using System.Windows.Forms;

namespace Geo.FormFactory.Interfaces
{
    public interface IFormFactory
    {
        T? Create<T>() where T : Form;
    }
}
