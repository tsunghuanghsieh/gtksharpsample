using Gtk;
using System;
using System.Text;

public partial class MainWindow : Gtk.Window
{
	// 
	// https://fossies.org/linux/misc/mono-sources/gtk-sharp212/gtk-sharp-2.12.26.tar.gz/gtk-sharp-2.12.26/sample/test/TestColorSelection.cs
    //
    // Gdk.Color ToString() returns in this format, rgb:ca99/7acd/7acd
    // while Gdk.Color.[Red|Green|Blue] is ushort (16 bits)
    // Gdk.Color.[Red|Green|Blue].ToString() returns a value between 0 and 65536.
    // This function will convert Gdk.Color to #RRGGBB hex format (color name).
    static string HexFormat(Gdk.Color color)
    {
        StringBuilder s = new StringBuilder();
        ushort[] vals = { color.Red, color.Green, color.Blue };
        char[] hexchars = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
                            'A', 'B', 'C', 'D', 'E', 'F'};
        s.Append('#');
        foreach (ushort val in vals) {
	        /* Convert to a range of 0-255, then lookup the
	         * digit for each half-byte */
	        byte rounded = (byte)(val >> 8);
	        s.Append(hexchars[(rounded & 0xf0) >> 4]);
	        s.Append(hexchars[rounded & 0x0f]);
        }
        return s.ToString();
   }
}
