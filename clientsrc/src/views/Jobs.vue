<template>
  <div class="jobs">
    WELCOME TO THE Jobs!!!
    <form @submit.prevent="addJob">
      <label for>Company</label>
      <input type="text" placeholder="company" v-model="newJob.company" />
      <label for>Title</label>
      <input type="text" placeholder="title" v-model="newJob.title" />
      <label for>Pay</label>
      <input type="number" v-model="newJob.pay" />
      <button class="btn btn-primary btn-sm" type="submit">Create Job</button>
    </form>
    <div v-for="job in jobs" :key="job.id">
      <router-link :to="{name: 'job', params: {jobId: job.id}}">{{job.company}} - {{job.title}}</router-link>
    </div>
  </div>
</template>

<script>
export default {
  name: "jobs",
  mounted() {
    this.$store.dispatch("getJobs");
  },
  data() {
    return {
      newJob: {},
    };
  },
  computed: {
    jobs() {
      return this.$store.state.jobs;
    },
  },
  methods: {
    addJob() {
      debugger;
      this.newJob.pay = +this.newJob.pay;
      this.$store.dispatch("addJob", this.newJob);
      this.newJob = {};
    },
  },
};
</script>