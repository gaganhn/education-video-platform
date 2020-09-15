<template>
  <div>
    <transition name="fade">
      <a @click="scrollTop" v-if="showScrollTop" class="btn btn-primary btn-lg back-to-top" role="button" title="Click to return on the top page" data-toggle="tooltip" data-placement="left">
        <i class="fa fa-arrow-up"></i>
      </a>
    </transition>
  </div>
</template>

<script>
export default {
  name: 'back-to-top',
  data() {
    return {
      showScrollTop: false,
    }
  },
  created () {
    window.addEventListener('scroll', this.handleScroll);
  },
  destroyed () {
    window.removeEventListener('scroll', this.handleScroll);
  },
  methods: {
    handleScroll () {
      this.showScrollTop = window.scrollY > 50 ? true : false;
    },
    scrollTop() {
      window.scrollTo(0,0);
    }
  }
}
</script>

<style scoped>
  .back-to-top {
    cursor: pointer;
    position: fixed;
    bottom: 20px;
    right: 20px;
    background-color: #54d400;
    border-color: #54d400;
  }

  .back-to-top .fa.fa-arrow-up {
    font-size: 25px;
    color: #fff;
    border: 0;
  }

  .btn-primary:hover {
    background-color: #54d400;
    border-color: #54d400;
  }

  .fade-enter-active,
  .fade-leave-active {
    transition: opacity .5s
  }

  .fade-enter,
  .fade-leave-to {
    opacity: 0
  }
</style>
