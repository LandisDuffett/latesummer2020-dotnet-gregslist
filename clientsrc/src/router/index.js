import Vue from 'vue'
import Router from 'vue-router'
import Home from '../views/Home.vue'
import Cars from '../views/Cars.vue'
import FavoriteCars from '../views/FavoriteCars.vue'
import FavoriteHouses from '../views/FavoriteHouses.vue'
import Car from '../views/Car.vue'
import Houses from '../views/Houses.vue'
import House from '../views/House.vue'
import Jobs from '../views/Jobs.vue'
import Job from '../views/Job.vue'
//import FavoriteHouses from '../views/FavoriteHouses.vue'
//import House from '../views/House.vue'
import { authGuard } from "@bcwdev/auth0-vue"

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/cars',
      name: 'cars',
      component: Cars,
      beforeEnter: authGuard
    },
    {
      path: '/mycars',
      name: 'mycars',
      component: FavoriteCars,
      beforeEnter: authGuard
    },
    {
      path: '/cars/:carId',
      name: 'car',
      component: Car
    },
    {
      path: '/houses',
      name: 'houses',
      component: Houses,
      beforeEnter: authGuard
    },
    {
      path: '/myhouses',
      name: 'myhouses',
      component: FavoriteHouses,
      beforeEnter: authGuard
    },
    {
      path: '/houses/:houseId',
      name: 'house',
      component: House
    },
    {
      path: '/jobs',
      name: 'jobs',
      component: Jobs,
      beforeEnter: authGuard
    },
    {
      path: '/jobs/:jobId',
      name: 'job',
      component: Job
    },
    {
      path: "*",
      redirect: '/'
    }
  ]
})