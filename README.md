Gibe.UmbracoGrid
------

A reusable strongly typed grid system based on Umbraco 

To use: 

- Install Gibe.UmbracoGrid package
- Introduce some grid content partial implementing a grid-based layout with a model of GridContentModel<T>, where T deserialises to your per-row settings model.
- Dispatch the Content property of each GridControl to some templating system which will accept an IPublishedContent

