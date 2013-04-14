$(document).ready(function () {

    //var store = new Ext.data.Store({

    //    proxy: new Ext.data.HttpProxy({
    //        url: 'Person/ListExtJs',
    //        dataType: 'json',
    //        method: 'GET'
    //    }),

    //    reader: new Ext.data.JsonReader({
    //        root: 'data',
    //        totalProperty: 'totalCount'
    //    }, Ext.data.Record.create([
    //       { name: 'Id', mapping: 'Id' },
    //       { name: 'FirstName', mapping: 'FirstName' },
    //       { name: 'MI', mapping: 'MI' },
    //       { name: 'LastName', mapping: 'LastName' },
    //       { name: 'FaceBookId', mapping: 'FaceBookId' },
    //       { name: 'Email', mapping: 'Email' },
    //       { name: 'TwitterId', mapping: 'TwitterId' },
    //       { name: 'LinkedInId', mapping: 'LinkedInId' },
    //       { name: 'BlogUrl', mapping: 'BlogUrl' }
    //    ]))
    //});


    // Set up a model to use in our Store
    Ext.define('Person', {
        extend: 'Ext.data.Model',
        fields: [
        { name: 'FirstName', type: 'string' },
        { name: 'FirstName', type: 'string' },
        { name: 'MI', type: 'string' },
        { name: 'LastName', type: 'string' },
        { name: 'FaceBookId', type: 'string' },
        { name: 'Email', type: 'string' },
        { name: 'TwitterId', type: 'string' },
        { name: 'LinkedInId', type: 'string' },
        { name: 'BlogUrl', type: 'string' }
        ]
    });

    var personstore = Ext.create('Ext.data.Store', {
        model: 'Person',
        proxy: {
            type: 'ajax',
            url: '/Person/ListExtJs',
            reader: {
                type: 'json',
                root: 'data'
            }
        },
        autoLoad: true
    });

    Ext.create('Ext.grid.Panel', {
        renderTo: 'grid',
        store: personstore,
        autoScroll: true,
        layout: 'fit',
        width: 800,
        height: 500,
        title: 'Persons',
        columns: [
       { header: 'Id', dataIndex: 'Id', hidden: true },
           { header: 'First Name', dataIndex: 'FirstName', width: 100 },
           { header: 'Middle Initial', dataIndex: 'MI', width: 100 },
           { header: 'Last Name', dataIndex: 'LastName', width: 100 },
           { header: 'FaceBook Id', dataIndex: 'FaceBookId', width: 100 },
           { header: 'Email', dataIndex: 'Email', width: 100 },
           { header: 'TwitterId', dataIndex: 'TwitterId', width: 100 },
           { header: 'LinkedInId', dataIndex: 'LinkedInId', width: 100 },
           { header: 'BlogUrl', dataIndex: 'BlogUrl', width: 200 }
        ]
    });


    //var grid = new Ext.grid.GridPanel({
    //    store: store,
    //    columns: [
    //       { header: 'Id', dataIndex: 'Id', hidden: true },
    //       { header: 'First Name', dataIndex: 'FirstName', width: 100 },
    //       { header: 'Middle Initial', dataIndex: 'MI', width: 100 },
    //       { header: 'Last Name', dataIndex: 'LastName', width: 100 },
    //       { header: 'FaceBook Id', dataIndex: 'FaceBookId', width: 100 },
    //       { header: 'Email', dataIndex: 'Email', width: 100 },
    //       { header: 'TwitterId', dataIndex: 'TwitterId', width: 100 },
    //       { header: 'LinkedInId', dataIndex: 'LinkedInId', width: 100 },
    //       { header: 'BlogUrl', dataIndex: 'BlogUrl', width: 200 }
    //    ],
    //    renderTo: 'grid',
    //    width: 1000,
    //    autoHeight: true,
    //    bbar: new Ext.PagingToolbar({
    //        store: store,
    //        pageSize: 25,
    //        displayInfo: true,
    //        displayMsg: 'Displaying employees {0} - {1} of {2}',
    //        emptyMsg: "No employees to display"
    //    }),
    //    pageSize: 20,
    //    title: 'Employees'
    //});

    //grid.getStore().load({
    //    params: {
    //        start: 0,
    //        limit: 25
    //    }
    //});
});