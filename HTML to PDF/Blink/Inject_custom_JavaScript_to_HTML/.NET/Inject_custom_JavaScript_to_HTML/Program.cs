﻿// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using System.IO;

//Initialize the HTML to PDF converter.
HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();

//Initialize the blink converter settings. 
BlinkConverterSettings blinkConverterSettings = new BlinkConverterSettings();
//Set the Blink viewport size.
blinkConverterSettings.ViewPortSize = new Size(1280, 0);
blinkConverterSettings.Margin.All = 30;

//Set the Custom JavaScript
blinkConverterSettings.JavaScript = "document.querySelectorAll('img').forEach((node)=>{node.remove();})";
htmlConverter.ConverterSettings = blinkConverterSettings;

//Convert the URL to PDF document.
PdfDocument document = htmlConverter.Convert("https://www.syncfusion.com");

//Create a filestream.
FileStream fileStream = new FileStream("../../../HTML-to-PDF.pdf", FileMode.CreateNew, FileAccess.ReadWrite);
//Save and close the PDF document.
document.Save(fileStream);
document.Close(true);
