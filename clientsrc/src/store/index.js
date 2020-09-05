import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from '../router/index'

Vue.use(Vuex)

//Allows axios to work locally or live
let base = window.location.host.includes('localhost') ? 'https://localhost:5001/' : '/'

let api = Axios.create({
  baseURL: base + "api/",
  timeout: 3000,
})

export default new Vuex.Store({
  state: {
    user: {},
    cars: [],
    activeCar: {},
    houses: [],
    activeHouse: {},
    jobs: [],
    activeJob: {}
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    setCars(state, cars) {
      state.cars = cars
    },
    setActiveCar(state, car) {
      state.activeCar = car
    },
    setHouses(state, houses) {
      state.houses = houses
    },
    setActiveHouse(state, house) {
      state.activeHouse = house
    },
    setJobs(state, jobs) {
      state.jobs = jobs
    },
    setActiveJob(state, job) {
      state.activeJob = job
    }
  },
  actions: {
    //#region -- AUTH STUFF --
    setBearer({ }, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },
    //#endregion


    //#region -- BOARDS --
    getCars({ commit }) {
      api.get('cars')
        .then(res => {
          commit('setCars', res.data)
        })
    },
    async addCar({ dispatch }, carData) {
      try {
        let res = await api.post('cars', carData)
        dispatch("getCars")
      } catch (error) {
        console.error(error)
      }
    },
    getHouses({ commit }) {
      api.get('houses')
        .then(res => {
          commit('setHouses', res.data)
        })
    },
    async addHouse({ dispatch }, houseData) {
      try {
        let res = await api.post('houses', houseData)
        dispatch("getHouses")
      } catch (error) {
        console.error(error)
      }
    },
    getJobs({ commit }) {
      api.get('jobs')
        .then(res => {
          commit('setJobs', res.data)
        })
    },
    async addJob({ dispatch }, jobData) {
      try {
        let res = await api.post('jobs', jobData)
        dispatch("getJobs")
      } catch (error) {
        console.error(error)
      }
    },
    async getActiveJob({ commit }, jobId) {
      try {
        let res = await api.get("jobs/" + jobId)
        commit("setActiveJob", res.data)
      } catch (error) {
        console.error(error);
      }
    },
    async getActiveHouse({ commit }, houseId) {
      try {
        let res = await api.get("houses/" + houseId)
        commit("setActiveHouse", res.data)
      } catch (error) {
        console.error(error);
      }
    },
    async getActiveCar({ commit }, carId) {
      try {
        let res = await api.get("cars/" + carId)
        commit("setActiveCar", res.data)
      } catch (error) {
        console.error(error);
      }
    },
    async addToFavorites({ commit, dispatch }, favoriteCar) {
      try {
        let res = await api.post("favoriteCars", favoriteCar)
        console.log(res.data)
      } catch (error) {
        console.error(error);
      }
    },
    async addToFavoriteHouses({ commit, dispatch }, favoriteHouse) {
      try {
        let res = await api.post("favoriteHouses", favoriteHouse)
        console.log(res.data)
      } catch (error) {
        console.error(error);
      }
    },
    async getFavoriteCars({ commit }) {
      try {
        let res = await api.get("favoriteCars")
        commit("setCars", res.data)
      } catch (error) {
        console.error(error);
      }
    },
    async getFavoriteHouses({ commit }) {
      try {
        let res = await api.get("favoriteHouses")
        commit("setHouses", res.data)
      } catch (error) {
        console.error(error);
      }
    }
    //#endregion


    //#region -- LISTS --



    //#endregion
  }
})
