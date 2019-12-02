namespace RecTracPom.OnScreenElements
{
    /// <summary>
    /// This interface is for use with MODULE pages - where module pages are the pages that contain a header table with filter text boxes and a data grid with the list of items for the given module.
    /// </summary>
    public interface IModule
    {

        Table DataGrid { get; }

        /// <summary>  This method performs actions in the filter text box.</summary>
        void DoPrimaryFilter(string value);

        string GetChangedText();

    }
}
