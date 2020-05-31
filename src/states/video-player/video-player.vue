<template>
  <div>
    <div class="main-content">
      <div class="wrap">
        <div class="right-content">
          <div class="right-content-heading">
            <div class="right-content-heading-left">
              <h3>Video Lectures</h3>
            </div>
            <div class="right-content-heading-right"></div>
            <div class="clear"></div>
          </div>
          <div class="inner-page">
            <!-- <div class="title">
              <h3>
                Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et
                dolore magna aliqua.Ut enim ad minim veniam, consectetur adipisicing elit, sed do eiusmod tempor
                incididunt ut labore et dolore magna aliqua.consectetur adipisicing elit, sed do eiusmod tempor incididunt
                ut labore et dolore
              </h3>
              <ul>
                <li>
                  <h4>By:</h4>
                </li>
                <li>
                  <a href="#">Author</a>
                </li>
                <li>
                  <a href="#">
                    <img src="../../assets/images/sub.png" title="subscribe" />subscribe
                  </a>
                </li>
              </ul>
            </div>-->
            <div class="video-inner">
              <video
                ref="lecture_video"
                width="100%"
                height="500px"
                frameborder="0"
                webkitallowfullscreen
                mozallowfullscreen
                allowfullscreen
                controls
                playsinline
                autoplay
                muted
              >
                <p>This browser does not support the video element.</p>
              </video>
            </div>
            <div class="clear"></div>
            <div class="video-details">
              <ul>
                <li>
                  <p>
                    Uploaded on
                    <a href="#">June 21, 2013</a>
                    <!-- by<a href="#">Lorem</a> -->
                  </p>
                </li>
                <!-- <li>
                  <span>
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut
                    labore et dolore magna aliqua. Ut enim ad minim veniam, consectetur adipisicing elit, sed do eiusmod
                    tempor incididunt ut labore et dolore magna aliqua.consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua.
                  </span>
                </li>-->
              </ul>
            </div>
            <div class="clear"></div>
            <!-- <div class="tags">
              <ul>
                <li>
                  <h3>Tags:</h3>
                </li>
                <li>
                  <a href="#">Games</a> ,
                </li>
                <li>
                  <a href="#">HD-Videos</a>
                </li>
              </ul>
            </div>-->
            <div class="clear"></div>
            <div class="share-artical">
              <h3>Also share on</h3>
              <ul>
                <li>
                  <a href="#">
                    <img src="../../assets/images/facebook.png" title="facebook" />Facebook
                  </a>
                </li>
                <li>
                  <a href="#">
                    <img src="../../assets/images/twiter.png" title="Twitter" />Twitter
                  </a>
                </li>
                <li>
                  <a href="#">
                    <img src="../../assets/images/in.png" title="linked-in" />Linked-in
                  </a>
                </li>
              </ul>
            </div>
            <div class="artical-commentbox">
              <h3>Leave a comment</h3>
              <div class="table-form">
                <form>
                  <input
                    type="text"
                    class="textbox"
                    value="Name:"
                    onfocus="this.value = '';"
                    onblur="if (this.value == '') {this.value = 'Name';}"
                  />
                  <input
                    type="text"
                    class="textbox"
                    value="Email:"
                    onfocus="this.value = '';"
                    onblur="if (this.value == '') {this.value = 'Email';}"
                  />
                  <input
                    type="text"
                    class="textbox"
                    value="Phone:"
                    onfocus="this.value = '';"
                    onblur="if (this.value == '') {this.value = 'Phone';}"
                  />
                  <textarea
                    value="Message:"
                    onfocus="this.value = '';"
                    onblur="if (this.value == '') {this.value = 'Message';}"
                  >Message:</textarea>
                </form>
                <a href="#">Submit Comment</a>
              </div>
            </div>
          </div>
        </div>
        <div class="clear"></div>
      </div>
    </div>
    <div class="clear"></div>
  </div>
</template>

<script src="./video-player.js"></script>
<style scoped src="./video-player.css"></style> 