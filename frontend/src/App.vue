<template>
  <BaseLayout>
    <RouterView />
  </BaseLayout>
</template>

<script>
import { RouterView } from 'vue-router'
import BaseLayout from './layouts/BaseLayout.vue'
import kazemaruApi from './api/kazemaruApi';
import { useProjectsStore } from './stores/projects';

export default {
  components: {
    BaseLayout,
    RouterView
  },
  data() {
    return {
      projects: []
    }
  },
  async mounted() {
    const { data } = await kazemaruApi.get('/projects/all');

    this.projects = data.data

    const { setProjects } = useProjectsStore();
    setProjects(this.projects)
  },
  setup() {
    return { projectsStore: useProjectsStore() }
  },
}
</script>

<style></style>