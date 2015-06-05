<%@ Page Title="" Language="C#" MasterPageFile="~/Pine.Master" AutoEventWireup="true" CodeBehind="Booking.aspx.cs" Inherits="PineForest.Booking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHeader" runat="server">
    <title>Pine Forest Munnar | Booking</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMenu" runat="server">
    <ul>
        <li><a class="scroll" href="Default.aspx">Home</a></li>
        <li><a class="scroll" href="facilities.aspx">FACILITIES</a></li>
        <li><a class="scroll" href="aboutmunnar.aspx">ABOUT MUNNAR</a></li>
        <li><a class="scroll" href="gallery.aspx">GALLERY</a></li>
        <li class="active"><a class="scroll" href="booking.aspx">BOOKING</a></li>
        <li><a class="scroll" href="contact.aspx">CONTACT US</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBanner" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpContent" runat="server">

    <div class="contact-bg2">
        <div class="container">
            <div class="booking">
                <h3>Booking</h3>
                <div class="col-md-8 booking-form">
                    <form>
                        <h5>NAME</h5>
                        <input type="text" value="">
                        <h5>E-MAIL</h5>
                        <input type="text" value="">
                        <h5>PHONE</h5>
                        <input type="text" value="">
                        <h5>TIME</h5>
                        <input type="text" value="" class="time">
                        <h5>CHECK IN</h5>
                        <select class="arrival">
                            <option>01</option>
                            <option>02</option>
                            <option>03</option>
                            <option>04</option>
                            <option>05</option>
                            <option>06</option>
                            <option>08</option>
                            <option>09</option>
                            <option>10</option>
                            <option>11</option>
                            <option>12</option>
                            <option>13</option>
                            <option>14</option>
                            <option>15</option>
                            <option>16</option>
                            <option>17</option>
                            <option>18</option>
                            <option>19</option>
                            <option>20</option>
                            <option>21</option>
                            <option>22</option>
                            <option>23</option>
                            <option>24</option>
                            <option>25</option>
                            <option>26</option>
                            <option>27</option>
                            <option>28</option>
                            <option>29</option>
                            <option>30</option>
                            <option>31</option>
                        </select>
                        <select class="arrival">
                            <option>Jan</option>
                            <option>Feb</option>
                            <option>Mar</option>
                            <option>Apr</option>
                            <option>May</option>
                            <option>June</option>
                            <option>July</option>
                            <option>Aug</option>
                            <option>Sep</option>
                            <option>Oct</option>
                            <option>Nov</option>
                            <option>Dec</option>
                        </select>
                        <select class="arrival">
                            <option>2012</option>
                            <option>2013</option>
                            <option>2014</option>
                            <option>2015</option>
                            <option>2016</option>
                            <option>2017</option>
                        </select>
                        <h5>CHECK OUT</h5>
                        <select class="arrival">
                            <option>01</option>
                            <option>02</option>
                            <option>03</option>
                            <option>04</option>
                            <option>05</option>
                            <option>06</option>
                            <option>08</option>
                            <option>09</option>
                            <option>10</option>
                            <option>11</option>
                            <option>12</option>
                            <option>13</option>
                            <option>14</option>
                            <option>15</option>
                            <option>16</option>
                            <option>17</option>
                            <option>18</option>
                            <option>19</option>
                            <option>20</option>
                            <option>21</option>
                            <option>22</option>
                            <option>23</option>
                            <option>24</option>
                            <option>25</option>
                            <option>26</option>
                            <option>27</option>
                            <option>28</option>
                            <option>29</option>
                            <option>30</option>
                            <option>31</option>
                        </select>
                        <select class="arrival">
                            <option>Jan</option>
                            <option>Feb</option>
                            <option>Mar</option>
                            <option>Apr</option>
                            <option>May</option>
                            <option>June</option>
                            <option>July</option>
                            <option>Aug</option>
                            <option>Sep</option>
                            <option>Oct</option>
                            <option>Nov</option>
                            <option>Dec</option>
                        </select>
                        <select class="arrival">
                            <option>2012</option>
                            <option>2013</option>
                            <option>2014</option>
                            <option>2015</option>
                            <option>2016</option>
                            <option>2017</option>
                        </select>
                        <h5 class="mem">MEMBERS</h5>
                        <input min="1" type="number" id="quantity" name="quantity" value="1" class="form-control input-small">
                        <h5>REQUIRED</h5>
                        <textarea value=""></textarea>
                        <input type="submit" value="Submit">
                        <input type="reset" value="Reset">
                    </form>
                </div>
                <div class="col-md-4 booking-news">
                    <%--<h4>Latest News</h4>			
				 <div class="LatestNews">
					 <h6><a href="#">Starting New Ventures for a Current Bussi</a></h6>
					 <span>01-7-2014 </span>
					 <p>Faworki bonbon marshmallow caramels applicake tart gummi bears liquorice.</p> 
				 </div>			
				 <div class="LatestNews">
					 <h6><a href="#">Starting New Ventures for a Current Bussi</a></h6>
					 <span>01-7-2014 </span>
					 <p>Faworki bonbon marshmallow caramels applicake tart gummi bears liquorice.</p> 
				 </div>	
					<div class="LatestNews">
					 <h6><a href="#">Starting New Ventures for a Current Bussi</a></h6>
					 <span>01-7-2014 </span>
					 <p>Faworki bonbon marshmallow caramels applicake tart gummi bears liquorice.</p> 
				 </div>	
				 <div class="LatestNews">
					 <h6><a href="#">Starting New Ventures for a Current Bussi</a></h6>
					 <span>01-7-2014 </span>
					 <p>Faworki bonbon marshmallow caramels applicake tart gummi bears liquorice.</p> 
				 </div>	--%>
                </div>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>

</asp:Content>
