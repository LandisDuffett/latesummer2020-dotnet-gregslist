<template>
  <div class="favorite-houses row">
    <div v-for="house in houses" class="col-3" :key="house.id">
      <h1>{{house.floors}}</h1>
      <h1>{{house.sizeSqFt}}</h1>
      <h1>{{house.price}}</h1>
      <h1>{{house.description}}</h1>
    </div>
  </div>
</template>


<script>
export default {
  name: "favorite-houses",
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getFavoriteHouses");
  },
  computed: {
    houses() {
      // NOTE this could also be favoriteCars, we can reuse this property.
      return this.$store.state.houses;
    },
  },
  methods: {},
  components: {},
};
</script>


<style lang="scss" scoped>
</style>