<%@ Page Title="" Language="C#" MasterPageFile="~/Pine.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="PineForest.Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHeader" runat="server">
    <title>Pine Forest Munnar | Contact US</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMenu" runat="server">
    <ul>
        <li><a class="scroll" href="Default.aspx">HOME</a></li>
        <li><a class="scroll" href="facilities.aspx">FACILITIES</a></li>
        <li><a class="scroll" href="aboutmunnar.aspx">ABOUT MUNNAR</a></li>
        <li><a class="scroll" href="gallery.aspx">GALLERY</a></li>        
        <li class="active"><a class="scroll" href="contact.aspx">CONTACT US</a></li>
        <li><a class="scroll" href="pinelogin.aspx">LOGIN</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBanner" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpContent" runat="server">
    <!---->
<div class="contact-bg">
	 <div class="container">
	      <div class="contact-us">				
				<div class="contact-us_left">
					<div class="contact-us_info">
			    	 	<h3 class="style">Find Us Here</h3>
			    	 		<div class="map">
								<small>
								<a href='https://goo.gl/maps/0wtOV' target='b'>
								<iframe src="https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d62852.41895442583!2d77.0926512!3d10.0764413!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3b070a69e121de61%3A0xe0b369073211c416!2sMunnar-Kumily+Hwy%2C+Devikulam%2C+Kerala+685613!5e0!3m2!1sen!2sin!4v1430188874372" width="400" height="300" frameborder="0" style="border:0"></iframe>								
								View Larger Map</a></small>
					   		</div>
      				</div>
      			 <div class="company_address">
				     	<h3 class="style">Hotel Information :</h3>
						<p>Pine Forest Residence,</p>
						<p>Munnar - Kumily Road, Devikulam</p>
						<p>Postal Code : 685 613</p>
						<p>India</p>
				   		<p>Phone 1:(+91) 949 573 0984</p>
				   		<p>Phone 2:(+91) 944 732 5677</p>
				 	 	<p>Email: <a href="mailto:info@example.com">info(at)PineForestMunnar.com</a></p>
				   		<p>Follow on: <a href="#">Facebook</a>, <a href="#">Twitter</a></p>
				   </div>
				</div>				
				<div class="contact_right">
				  <div class="contact-form">
				  	<h3 class="style">Contact Us</h3>
					    <form method="post" action="index.html">
					    	<div>
						    	<span><label>NAME</label></span>
						    	<span><input name="userName" type="text" class="textbox"></span>
						    </div>
						    <div>
						    	<span><label>E-MAIL</label></span>
						    	<span><input name="userEmail" type="text" class="textbox"></span>
						    </div>
						    <div>
						     	<span><label>MOBILE</label></span>
						    	<span><input name="userPhone" type="text" class="textbox"></span>
						    </div>
						    <div>
						    	<span><label>SUBJECT</label></span>
						    	<span><textarea name="userMsg"> </textarea></span>
						    </div>
						   <div>
						   		<input type="submit" value="submit us">
						  </div>
					    </form>
				    </div>
  				</div>		
  				<div class="clear"></div>		
		  </div>
	 </div>	
</div>	 
<!---->
</asp:Content>
