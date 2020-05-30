<template>
  <div>
    <AppHeader></AppHeader>
    <b-container>
      <!-- <Listing></Listing> -->
      <router-view></router-view>
    </b-container>
    <!--footer section-->
    <section class="py-5 bg-dark text-white">
      <div class="container">
        <div class="row">
          <div class="col-md-12">
            <h5>About Us</h5>
            <p>Lorem Ipsum Generator. With our simple and useful tool you can generate a standard text which you can place in your web design to look more realistic.</p>
          </div>
        </div>
      </div>
    </section>
    <BackToTop></BackToTop>
  </div>
</template>

<script>
import AppHeader from "./components/Header.vue";
// import Listing from "./states/listing.vue";
import BackToTop from "./components/back-to-top.vue";

export default {
  name: "App",
  components: {
    AppHeader,
    // Listing,
    BackToTop
  }
};
</script>

<style>
</style>
