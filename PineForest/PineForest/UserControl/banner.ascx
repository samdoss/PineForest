<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="banner.ascx.cs" Inherits="PineForest.UserControl.banner" %>

<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="UTF-8" />
        <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1"> 
        <meta name="viewport" content="width=device-width, initial-scale=1.0"> 
        <meta name="description" content="Elastic Image Slideshow with Thumbnail Preview" />
        <meta name="keywords" content="jquery, css3, responsive, image, slider, slideshow, thumbnails, preview, elastic" />
        <meta name="author" content="Codrops" />
        <link rel="stylesheet" type="text/css" href="../UserControl/css/demo.css" />
        <link rel="stylesheet" type="text/css" href="../UserControl/css/style.css" />
        <link href='http://fonts.googleapis.com/css?family=Open+Sans+Condensed:300|Playfair+Display:400italic' rel='stylesheet' type='text/css' />
		<noscript>
			<link rel="stylesheet" type="text/css" href="../UserControl/css/noscript.css" />
		</noscript>
   </head>
    <body>
        <div class="container">
           <%-- <div class="header">
                <a href="http://tympanus.net/Development/FullscreenImageBlurEffect/">
                    <strong>&laquo; Previous Demo: </strong>Fullscreen Image Blur Effect
                </a>
                <span class="right">
                    <a href="http://barbragolba.deviantart.com/gallery/#/d40lc1t" target="_blank">Images by BarbraGolba</a>
                    <a href="http://tympanus.net/codrops/2011/11/21/elastic-image-slideshow-with-thumbnail-preview/">
                        <strong>Back to the Codrops Article</strong>
                    </a>
                </span>
                <div class="clr"></div>
            </div>--%>
            <%--<h1>Elastic Image Slideshow with Thumbnail Preview</h1>--%>
            <div class="wrapper">
                <div id="ei-slider" class="ei-slider">
                    <ul class="ei-slider-large">
						<li>
                            <img src="../UserControl/images/large/banner1.jpg" alt="image06"/>
                            <div class="ei-title">
                                <h2>Munnar</h2>
                                <h3>HoneyMoon Package</h3>
                            </div>
                        </li>
                        <li>
                            <img src="../UserControl/images/large/banner2.jpg" alt="image01" />
                            <div class="ei-title">
                                <h2>Per Couple</h2>
                                <h3>Rs. 11,000 Only</h3>                                
                            </div>
                        </li>                        
                    </ul><!-- ei-slider-large -->
                    <ul class="ei-slider-thumbs">
                        <li class="ei-slider-element">Current</li>						
                        <li><a href="#">Slide 1</a><img src="../UserControl/images/thumbs/banner1_thumb.jpg" alt="thumb01" /></li>
                        <li><a href="#">Slide 2</a><img src="../UserControl/images/thumbs/banner2_thumb.jpg" alt="thumb02" /></li>                        
                    </ul><!-- ei-slider-thumbs -->
                </div><!-- ei-slider -->
                <div class="reference">
                </div>
            </div><!-- wrapper -->
        </div>
        <%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.0/jquery.min.js"></script>--%>
        <script type="text/javascript" src="../UserControl/js/jquery.eislideshow.js"></script>
        <script type="text/javascript" src="../UserControl/js/jquery.easing.1.3.js"></script>
        <script type="text/javascript">
            $(function() {
                $('#ei-slider').eislideshow({
					animation			: 'center',
					autoplay			: true,
					slideshow_interval	: 3000,
					titlesFactor		: 0
                });
            });
        </script>
    </body>
</html>
