<template>
  <div class="houses">
    WELCOME TO THE Houses!!!
    <form @submit.prevent="addHouse">
      <label for>Floors</label>
      <input type="number" placeholder="floors" v-model="newHouse.floors" required />
      <label for>Size in Square Feet</label>
      <input type="number" placeholder="sizeSqFt" v-model="newHouse.sizeSqFt" />
      <label for>Price</label>
      <input type="number" v-model="newHouse.price" />
      <label for>Image</label>
      <input type="text" placeholder="Image url" v-model="newHouse.imgUrl" />
      <label for>Description</label>
      <input type="text" placeholder="description" v-model="newHouse.description" />
      <button class="btn btn-primary btn-sm" type="submit">Create House</button>
    </form>
    <div v-for="house in houses" :key="house.id">
      <router-link
        :to="{name: 'house', params: {houseId: house.id}}"
      >{{house.description}} - {{house.price}}</router-link>
    </div>
  </div>
</template>

<script>
export default {
  name: "houses",
  mounted() {
    this.$store.dispatch("getHouses");
  },
  data() {
    return {
      newHouse: {},
    };
  },
  computed: {
    houses() {
      return this.$store.state.houses;
    },
  },
  methods: {
    addHouse() {
      this.newHouse.floors = +this.newHouse.floors;
      this.newHouse.price = +this.newHouse.price;
      this.newHouse.sizeSqFt = +this.newHouse.sizeSqFt;
      this.$store.dispatch("addHouse", this.newHouse);
      this.newHouse = {};
    },
  },
};
</script>