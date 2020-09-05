<template>
  <div class="house">
    <div v-if="house.floors">
      <h1>{{house.sizeSqFt}}</h1>
      <h1>{{house.price}}</h1>
      <img :src="house.imgUrl" alt />
      <button class="btn btn-warning" @click="addToFavoriteHouses()">Favorite</button>
    </div>
    <h1 v-else>Loading...</h1>
  </div>
</template>

<script>
export default {
  name: "house",
  mounted() {
    this.$store.dispatch("getActiveHouse", this.$route.params.houseId);
  },
  computed: {
    house() {
      return this.$store.state.activeHouse;
    },
  },
  methods: {
    addToFavoriteHouses() {
      let favoriteHouse = {
        houseId: this.house.id,
      };
      this.$store.dispatch("addToFavoriteHouses", favoriteHouse);
    },
  },
};
</script>
