import Vue from 'vue'
import Router from 'vue-router';
import { BootstrapVue, IconsPlugin } from 'bootstrap-vue'
import App from './App.vue'
import ListingPage from './states/listing.vue'
import VideoPlayer from './states/video-player.vue'

// Install BootstrapVue
Vue.use(BootstrapVue)
// Optionally install the BootstrapVue icon components plugin
Vue.use(IconsPlugin)

import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import 'font-awesome/css/font-awesome.min.css'

import './elementUI.js'

Vue.config.productionTip = false

const router = new Router({
  routes: [
    { path: '/', component: ListingPage },
    { path: '/video', component: VideoPlayer }
  ] 
})

Vue.use(Router);

new Vue({
  render: h => h(App),
  router: router
}).$mount('#app')
