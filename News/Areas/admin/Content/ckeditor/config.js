/**
 * @license Copyright (c) 2003-2016, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function (config) {
    // Define changes to default configuration here. For example:
    // config.language = 'fr';
    // config.uiColor = '#AADC6E';
    //config.height = 300;
    //config.toolbarCanCollapse = true;
    //config.extraPlugins = 'syntaxhighight';
    //config.skin = 'office2013';
    
    //config.extraPlugins = 'youtube';
   
    //config.extraPlugins = 'imageuploader';
    //config.extraPlugins = 'uploadcare';
    config.skin = 'moonocolor';
    config.syntaxhighlight_lang = 'csharp';
    config.syntaxhighlight_hideControls = true;
    config.language = 'vi';
    //config.toolbarGroups = [
	//	{ name: 'clipboard', groups: ['clipboard', 'undo'] },
	//	{ name: 'editing', groups: ['find', 'selection', 'spellchecker', 'editing'] },
	//	{ name: 'links', groups: ['links'] },
	//	{ name: 'insert', groups: ['insert'] },
	//	{ name: 'forms', groups: ['forms'] },
	//	{ name: 'tools', groups: ['tools'] },
	//	{ name: 'document', groups: ['mode', 'document', 'doctools'] },
	//	{ name: 'others', groups: ['others'] },
	//	'/',
	//	{ name: 'basicstyles', groups: ['basicstyles', 'cleanup'] },
	//	{ name: 'paragraph', groups: ['list', 'indent', 'blocks', 'align', 'bidi', 'paragraph'] },
	//	{ name: 'styles' },
	//	{ name: 'colors' }

    //];
    config.toolbar = [
		{ name: 'clipboard', items: ['Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord', '-', 'Undo', 'Redo'] },
		{ name: 'editing', items: ['Scayt'] },
		{ name: 'links', items: ['Link', 'Unlink', 'Anchor'] },
		{ name: 'insert', items: ['Image', 'Table', 'Flash', 'HorizontalRule', 'SpecialChar','Youtube'] },
		{ name: 'tools', items: ['Maximize', 'ShowBlocks'] },
		{ name: 'document', items: ['Source'] },		
		'/',
		{ name: 'basicstyles', items: ['Bold', 'Italic', 'Underline', 'Strike', 'Subscript', 'Superscript', '-', 'RemoveFormat'] },
		{ name: 'paragraph', items: ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', '-','JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyFull','-','Blockquote'] },
		{ name: 'styles', items: ['Styles', 'Format'] },
        { name: 'colors', items: ['TextColor', 'BGColor'] }
        //{ name: 'insert', items: ['Youtube'] }
        

    ];
    config.removeButtons = 'Underline,Subscript,Superscript';


    config.filebrowserBrowseUrl = '/Areas/admin/Content/ckfinder/ckfinder.html';
    config.filebrowserImageUrl = '/Areas/admin/Content/ckfinder/ckfinder.html?Type=Images';
    config.filebrowserFlashUrl = '/Areas/admin/Content/ckfinder/ckfinder.html?Type=Flash';
    config.filebrowserUploadUrl = '/Areas/admin/Content/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload@type=Files';
    config.filebrowserImageUploadUrl = '/Areas/admin/Content/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload@type=Images';
    config.filebrowserFlashUploadUrl = '/Areas/admin/Content/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload@type=Flash';


    config.extraPlugins = 'colorbutton';
    config.extraPlugins = 'youtube';
    //Video width:

    config.youtube_width = '640';
   // Video height:

    config.youtube_height = '480';
   // Show related videos:

    config.youtube_related = true;
    //Use old embed code:

    config.youtube_older = false;
    //Enable privacy-enhanced mode:
    config.youtube_privacy = false;
   
    //config.extraPlugins = 'tabletoolstoolbar';
    
    

    CKFinder.setupCKEditor(null, "/Areas/admin/Content/ckfinder");
};
