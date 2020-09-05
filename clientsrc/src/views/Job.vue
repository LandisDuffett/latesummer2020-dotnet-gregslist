<template>
  <div class="job">
    <div v-if="job.company">
      <h1>{{job.company}}</h1>
      <h1>{{job.title}}</h1>
      <h1>{{job.pay}}</h1>
      <button class="btn btn-warning" @click="addToFavorites()">Favorite</button>
    </div>
    <h1 v-else>Loading...</h1>
  </div>
</template>

<script>
export default {
  name: "job",
  mounted() {
    this.$store.dispatch("getActiveJob", this.$route.params.jobId);
  },
  computed: {
    job() {
      return this.$store.state.activeJob;
    },
  },
  methods: {
    addToFavorites() {
      let favoriteJob = {
        jobId: this.job.id,
      };
      this.$store.dispatch("addToFavorites", favoriteJob);
    },
  },
};
</script>
