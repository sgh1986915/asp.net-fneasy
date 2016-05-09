
<head runat="server">
  <title></title>
  <link href="css/style.css" rel="stylesheet" type="text/css" />


  <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.3.2/jquery.min.js"></script>
  <script type="text/javascript" src="js/stepcarousel.js"></script>
  <style type="text/css">
    .stepcarousel{
    position: relative; /*leave this value alone*/
    border: 0px;
    overflow: scroll; /*leave this value alone*/
    width: 948px; /*Width of Carousel Viewer itself*/
    height: 220px; /*Height should enough to fit largest content's height*/
    }
    .stepcarousel .belt{
    position: absolute; /*leave this value alone*/
    left: 0;
    top: 0;
    }
    .stepcarousel .panel{
    float: left; /*leave this value alone*/
    overflow: hidden; /*clip content that go outside dimensions of holding panel DIV*/
    margin: 10px; /*margin around each panel*/
    width: 303px; /*Width of each panel holding each content. If removed, widths should be individually defined on each content DIV then. */
    }
  </style>
  <script type="text/javascript">
    stepcarousel.setup({
    galleryid: 'mygallery', //id of carousel DIV
    beltclass: 'belt', //class of inner "belt" DIV containing all the panel DIVs
    panelclass: 'panel', //class of panel DIVs each holding content
    autostep: { enable: true, moveby: 1, pause: 4000 },
    panelbehavior: { speed: 500, wraparound: true, wrapbehavior: 'slide', persist: true },
    defaultbuttons: { enable: true, moveby: 1, leftnav: ['IMAGES/LeftArrow.png', -18, 90], rightnav: ['IMAGES/RightArrow.png', -8, 90] },
    statusvars: ['statusA', 'statusB', 'statusC'], //register 3 variables that contain current panel (start), current panel (last), and total panels
    contenttype: ['inline'] //content setting ['inline'] or ['ajax', 'path_to_external_file']
    })
  </script>
</head>