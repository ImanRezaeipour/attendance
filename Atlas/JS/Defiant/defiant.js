
if (typeof module === "undefined") {
	var module = { exports: undefined };
} else {
	// Node env adaptation goes here...
}

module.exports = Defiant = (function(window, undefined) {
	'use strict';

	var Defiant = {
	    //is_ie     : /msie/i.test(navigator.userAgent),
	    is_ie: ((navigator.userAgent.indexOf('msie') >= 0) || ((navigator.appName == 'Netscape') && (new RegExp("Trident/.*rv:([0-9]{1,}[\.0-9]{0,})").exec(navigator.userAgent) != null))),
		is_safari : /safari/i.test(navigator.userAgent),
		env       : 'production',
		xml_decl  : '<?xml version="1.0" encoding="utf-8"?>',
		namespace : 'xmlns:d="defiant-namespace"',
		tabsize   : 4,
		render: function(template, data) {
			var processor = new XSLTProcessor(),
				span      = document.createElement('span'),
				opt       = {match: '/'},
				tmplt_xpath,
				scripts,
				temp,
				sorter;
			// handle arguments
			switch (typeof(template)) {
				case 'object':
					this.extend(opt, template);
					if (!opt.data) opt.data = data;
					break;
				case 'string':
					opt.template = template;
					opt.data = data;
					break;
				default:
					throw 'error';
			}
			opt.data = JSON.toXML(opt.data);
			tmplt_xpath = '//xsl:template[@name="'+ opt.template +'"]';

			if (!this.xsl_template) this.gather_templates();

			if (opt.sorter) {
				sorter = this.node.selectSingleNode(this.xsl_template, tmplt_xpath +'//xsl:for-each//xsl:sort');
				if (sorter) {
					if (opt.sorter.order) sorter.setAttribute('order', opt.sorter.order);
					if (opt.sorter.select) sorter.setAttribute('select', opt.sorter.select);
					sorter.setAttribute('data-type', opt.sorter.type || 'text');
				}
			}

			temp = this.node.selectSingleNode(this.xsl_template, tmplt_xpath);
			temp.setAttribute('match', opt.match);
			processor.importStylesheet(this.xsl_template);
			span.appendChild(processor.transformToFragment(opt.data, document));
			temp.removeAttribute('match');

			if (this.is_safari) {
				scripts = span.getElementsByTagName('script');
				for (var i=0, il=scripts.length; i<il; i++) scripts[i].defer = true;
			}
			return span.innerHTML;
		},
		gather_templates: function() {
			var scripts = document.getElementsByTagName('script'),
				str     = '',
				i       = 0,
				il      = scripts.length;
			for (; i<il; i++) {
				if (scripts[i].type === 'defiant/xsl-template') str += scripts[i].innerHTML;
			}
			this.xsl_template = this.xmlFromString('<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" '+ this.namespace +'>'+ str.replace(/defiant:(\w+)/g, '$1') +'</xsl:stylesheet>');
		},
		xmlFromString: function(str) {
			var parser,
				doc;
			str = str.replace(/>\s{1,}</g, '><');
			if (str.trim().match(/<\?xml/) === null) {
				str = this.xml_decl + str;
			}
			if (this.is_ie) {
				doc = new ActiveXObject('Msxml2.DOMDocument');
				doc.loadXML(str);
				if (str.indexOf('xsl:stylesheet') === -1) {
					doc.setProperty('SelectionLanguage', 'XPath');
				}
			} else {
				parser = new DOMParser();
				doc = parser.parseFromString(str, 'text/xml');
			}
			return doc;
		},
		extend: function(src, dest) {
			for (var content in dest) {
				if (!src[content] || typeof(dest[content]) !== 'object') {
					src[content] = dest[content];
				} else {
					this.extend(src[content], dest[content]);
				}
			}
			return src;
		},
		node: {}
	};

	return Defiant;

})(this);

