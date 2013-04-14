Ext.Loader.setConfig({ enabled: true });

Ext.require([
    'Ext.grid.*',
    'Ext.data.*',
    'Ext.ux.grid.FiltersFeature',
    'Ext.toolbar.Paging',
    'Ext.ux.ajax.JsonSimlet',
    'Ext.ux.ajax.SimManager'
]);


Ext.onReady(function () {

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

    var store = Ext.create('Ext.data.Store', {
        model: 'Person',
        remoteSort: true,
        proxy: {
            type: 'ajax',
            url: '/Person/ListExtJs',
            reader: {
                type: 'json',
                root: 'data',
                totalProperty: 'totalCount'
            }
        },
        autoLoad: true,
        
    });

    // configure whether filter query is encoded or not (initially)
    var encode = true;

    // configure whether filtering is performed locally or remotely (initially)
    var local = true;

    var filters = {
        ftype: 'filters',
        encode: encode, 
        local: false
    };

    var grid = new Ext.grid.GridPanel({
        store: store,
        columns: [
           { header: 'Id', dataIndex: 'Id', hidden: true},
           { header: 'First Name', dataIndex: 'FirstName', width: 100, filterable:true },
           {
               header: 'Middle Initial', dataIndex: 'MI', width: 100
           },
           { header: 'Last Name', dataIndex: 'LastName', width: 100 },
           {
               header: 'FaceBook Id', dataIndex: 'FaceBookId', width: 100,
               filter: {
                   type: 'string'
                   // specify disabled to disable the filter menu
                   //, disabled: true
               }
           },
           {
               header: 'Email', dataIndex: 'Email', width: 100,
               filter: {
                   type: 'string'
                   // specify disabled to disable the filter menu
                   //, disabled: true
               }
           },
           {
               header: 'TwitterId', dataIndex: 'TwitterId', width: 100,
               filter: {
                   type: 'string'
                   // specify disabled to disable the filter menu
                   //, disabled: true
               }
           },
           { header: 'LinkedInId', dataIndex: 'LinkedInId', width: 100 },
           { header: 'BlogUrl', dataIndex: 'BlogUrl', width: 200 }
        ],
        
        renderTo: 'grid',
        width: 1000,
        autoHeight: true,
        bbar: new Ext.PagingToolbar({
            store: store,
            pageSize: 5,
            displayInfo: true,
            displayMsg: 'Displaying employees {0} - {1} of {2}',
            emptyMsg: "No employees to display"
        }),
        pageSize: 25,
        title: 'Employees',
        features: [filters],
    });
                
    grid.getStore().load({ params: {
        start: 0,
        limit: 25
    }
    });
});