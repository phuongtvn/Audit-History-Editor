using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Reflection;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace Audit_History_Editor
{
    // Do not forget to update version number and author (company attribute) in AssemblyInfo.cs class
    // To generate Base64 string for Images below, you can use https://www.base64-image.de/
    [Export(typeof(IXrmToolBoxPlugin)),
        ExportMetadata("Name", "Audit History Editor"),
        ExportMetadata("Description", "View & Rollback from Audit History"),
        // Please specify the base64 content of a 32x32 pixels image
        ExportMetadata("SmallImageBase64", "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAA7AAAAOwBeShxvQAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAATBSURBVFiFvZbfa1xFFMe/59659+4mzc82IQ1rbRsiiqZCa6mNrdWKfSgi+uSD6IM+KD6k4JMQCkXRv8BHERTBHygawdpSqZXSCv56sPQHrLVNajZtfm12N7v318w9PiR7793t7s0uggcG9ux858znnpk5M4SY+cXiAWjaeTSxlaL8PQiwp1n/8opzUVilw6Ojo24zTb2JD6ednVVnTnlbtmoJaoKRFMxXatwtpc9ls9knWoXQdML1artsGx8nqjkZACAo5keLxdS32WzWagmgNj66ksNDbNBftSOlUupMKxBJCW80Q3IGYgTMOFgppy9uBJH4RXJxHv6dudBfvV7oUTJi6Dy0G6Trzccr3u3YnZdzudyu4eHhStsA9pVLKJ45Gfr5P7xe+7YX+jv2PQTqTId+f7eFgO8KM8IevwLg/bYBzHu2Y9PBw6EvB0tuyjFSVZ/M2uFCNM2GataRCGDtGIG1YyT0aVz6UiKVMKRtSwTwfYYno5wWVv2059V+TF/3f+NJBFCK4bpB6DuOL2z3fwQwTEJXbF05sOD4d++yRqZgw6ZLcDGNqwXnhXd/fnsXgB+78r1TE0cnwipJH804YcQBwXi6u+l+Qams4LcAsIpfsUzfIYADALiytG0mV5bb1rtvBhq9enzf8bPABoXI8wIUSipsi3kHd5bKYeMGLAX6CYv0VTg5AIClGZNs1wI+/d7Fd54BNliCIFjbB1WTMoAvoz3BYFCs/LmYQR6n7opDFBh13yqY+JMTF07cl3wMLQ2WFQ0Uege8GIBGVKMv0FkAjZZImoCJ/X2HMOvMYMa+AQA9QtOOJQIwfASQURhwzANMmDGtRAV/1UWgNSCC8Vjfk3hg0xjuTY9g1rkFxRIEejYRYME7j1knKsWXFrbjjh2V4pczr8OkNQiFAhDDM7XN2NnxEqbtzzHW+biVMcdgB2WcWvgGiqs63pl8DKkLHXom9LtENzwjSjExhTcgobYMbzb2oEPP4P7OYyiRopJTwcn5r7Eil+MyNxGg39yLfnNv6A9DeVKy2UiroRs60lCwAQBz7hkIrQMD5gFU1BKfnP+e8rWTA+DLyZUwYATRnoPnK+V60R8pU4DCDGhI8xhW6ZdqcNyyp6ACG78Vbzp5WYquzXB+7bPku8BjVJxownzBScVL8fDgpppj2IunUMGfsRrAyLmnseINOoCoB7jWtdLzQWIh0nUKj6JlaUhZutOZNlBtVKcX6MEAvwhC/SqJ+gfqbKDouYmjE8l7wDAIhhFNI6W1pBQyCUOQxii28htYxhQcugEAYBbe+gkJAHwBQ3/z+P7JuTXoNoyIvMaFptZMDGEIr8HnBbi4hUz69oVcOfsWmeLc5COTc3FtWwDM8NvRGxiAgQE83IHzR8Z7P22kae9VDG4LoBVrC0BxC/lv02qWoKCAs6Xmz+z8iqOXPX8xYPQxcVMhgXydsNQn6Mvx3tSUYHWtJQCPCbcTkjxr+/2OL7c0V4RmABiaBlaff3DohySh+Du3+A+IBUHTCSxAmg6wIIAZJJlZApBglktzdsVzlEYadAZ0WrsAdDBpBFYAqQAcEEMyIyCx8aYVDM6AAcZ6xePmTzIOeAbgQa5Ko57131zzP0tqeG/E7V+66BoppuA1CQAAAABJRU5ErkJggg=="),
        // Please specify the base64 content of a 80x80 pixels image
        ExportMetadata("BigImageBase64", "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAFAAAABQCAMAAAC5zwKfAAABVlBMVEVHcEyFx4Ko4vmFx4Lu6fHNzePOzuTp5fDOzuV3vr3u6PGh4viFx4KFx4K92ev18fSFx4KFx4Joqdie0n+Gx4KFx4JtsNt9yOOFx4Jvs9yg4feFx4KI0OmFx4LV2teHz+i22ZLF2+zD3u3f3OyFx4KFx4L////p4oL89PTp5PCh4viFx4LJ5WjNzeN+yONnp9fq5fGg4vj89fbV7fZ9yOPJ5Wfv6vLm4e/c2er38fPo4/CK0ergcGZvstvR0OX79PTn5O282eyp13Ti3u3z7fPO5njGJVmDx4DnkIjZ1+nl4+nR5oXL5m6IyIX59O6z1LTd65+s0q308uDm5eDV1Ofo3eri5NLU5pbb5bTX392Ry5Dm0eD45+bOUX3n7b/67e3PVn/e4uPW5Z/w8dX22Nan0aff3OvUbZDNOV3FIlfZjKvA3a3E2cj57OznOQCbAH4AwWVHcExTj240AAAAcnRSTlMA9lYu/YX3ig0L8vTkdPucTLC+/RjG/MGf7fuH8tqg5dfg7G6Tki7//////////////////////////////////////////////////////////////////////////////////////////////////wCCvBU6AAADW0lEQVRYw+XY/VPaMBgHcLFuiIMBAxyg6F7vZOlcfakM3KQq6KAFEWZB96Ywdc7t//91gSaloekLKbfbue9PcPQ+96R5kqZMTeGEi6bMZU3JLc1OuYwZzNPA+/dmmUFqhTuuRbfgawdxGie84hJ0EB/gbJhBgQ7ai69Q1ijgjAVoKzKBdiIbaCPagVvWoLXIClqKzKCVaAsKODTQQjSBK/nPOJ9wTqggXTSB698/4Jx/QfmZo4JUkQK+w/lxoOXmWi8x95ZI5TkTeDAER+N3MSkG8MZUIQNouIfX51oM95ClwuI3lN8nerKeQLvGvptgvoSzb+i4ggcQr9zCx+Ga2Mn9F2DWAYTXSa5mOY8j7Q9jnpSW2um2n0SToQg3gbapql1Z4UVxDwDgyyQjAY+g2lVEkYfpgzDBJOcJ7JQ1TgdBLRMKON/DbA6HHG5HQdwQhANfCFjOMk5lB6VSsPAMIBZd9SEBGj0jCHwhJlAtGzwCBMEIA1htGz0EHiIxGqeCWzhXFZQrHZRUxQzWzmqIjDicvgo4eoESWaAGXp4eITEaGLMPBfIOauDlhVA9quG7OCbY4flREHpZXQzRwDqOIOHoI+4OCxwslr2BB8FjDYxSnsvNBs7tMcoviTLHbRl+3kMeKhBkKKevHlz3WmKHKMcYbMk62Gj24Jc26QEfpcKegobEx9BVNLBRLxZ7crtFejTQXYVycx1e22yWSI9eoVxGiZ2hHI2CYvmrdnGJ9ECQMsv1Js7FKcoF7hq9r7FYIj2QcOjD0SN2Vu9DJJZID7wcs7GHS1nUxBnS8427Uox90xfrt4QHEnF3j9EcZcyDGhvEfgjAgssHvWE/NJTIiwq5wYIMx7BjdxTeascePAPGBqtdS7C/YTM8pIyDJsAE5/rAuU8eG2QqqHkMJweh0GrzogmMckxv9PhZX0YkBjOhuLfTl9qFJNyzB6Av+ILzepwTpFanDbelWDCTSIa4Cb1WVFV1iePiE3xPEQS/179ZvL1JTRrMT7zCuTsPjgaC8BgkUNul/4sDuLthyrOHMLu09H94Gvb7/dOWICRHk97etMvjgO2faZSsba/a5W+B6XR6jZ50epFlyMuL2xZZXE6lUu8tMj+fekQHbca0Of/GLuODq5MGN/8J8A85Vwu/S/H0VAAAAABJRU5ErkJggg=="),
        ExportMetadata("BackgroundColor", "Lavender"),
        ExportMetadata("PrimaryFontColor", "Black"),
        ExportMetadata("SecondaryFontColor", "Gray")]
    public class MyPlugin : PluginBase
    {
        public override IXrmToolBoxPluginControl GetControl()
        {
            return new MyPluginControl();
        }

        /// <summary>
        /// Constructor 
        /// </summary>
        public MyPlugin()
        {
            // If you have external assemblies that you need to load, uncomment the following to 
            // hook into the event that will fire when an Assembly fails to resolve
            // AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(AssemblyResolveEventHandler);
        }

        /// <summary>
        /// Event fired by CLR when an assembly reference fails to load
        /// Assumes that related assemblies will be loaded from a subfolder named the same as the Plugin
        /// For example, a folder named Sample.XrmToolBox.MyPlugin 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private Assembly AssemblyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            Assembly loadAssembly = null;
            Assembly currAssembly = Assembly.GetExecutingAssembly();

            // base name of the assembly that failed to resolve
            var argName = args.Name.Substring(0, args.Name.IndexOf(","));

            // check to see if the failing assembly is one that we reference.
            List<AssemblyName> refAssemblies = currAssembly.GetReferencedAssemblies().ToList();
            var refAssembly = refAssemblies.Where(a => a.Name == argName).FirstOrDefault();

            // if the current unresolved assembly is referenced by our plugin, attempt to load
            if (refAssembly != null)
            {
                // load from the path to this plugin assembly, not host executable
                string dir = Path.GetDirectoryName(currAssembly.Location).ToLower();
                string folder = Path.GetFileNameWithoutExtension(currAssembly.Location);
                dir = Path.Combine(dir, folder);

                var assmbPath = Path.Combine(dir, $"{argName}.dll");

                if (File.Exists(assmbPath))
                {
                    loadAssembly = Assembly.LoadFrom(assmbPath);
                }
                else
                {
                    throw new FileNotFoundException($"Unable to locate dependency: {assmbPath}");
                }
            }

            return loadAssembly;
        }
    }
}