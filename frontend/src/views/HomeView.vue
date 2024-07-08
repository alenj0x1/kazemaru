<script>
import { useProjectsStore } from '@/stores/projects';

export default {
  setup() {
    return {
      projectsStore: useProjectsStore()
    }
  }
}
</script>

<template>
  <h2>Good morning, <span class="accent">username</span></h2>

  <div class="cards-container">
    <div class="card gd-yellow">
      <span class="card-name">All</span>
      <span class="card-value">{{ projectsStore.projects.length }}</span>
    </div>

    <div class="card gd-blue">
      <span class="card-name">Pending</span>
      <span class="card-value">{{ projectsStore.projects.length }}</span>
    </div>

    <div class="card gd-green">
      <span class="card-name">In progress</span>
      <span class="card-value">{{ projectsStore.projects.length }}</span>
    </div>

    <div class="card gd-zinc">
      <span class="card-name">Ended</span>
      <span class="card-value">{{ projectsStore.projects.length }}</span>
    </div>
  </div>
</template>

<style>
.cards-container {
  @apply grid gap-4 grid-cols-1 md:grid-cols-2 xl:grid-cols-4 my-7
}

.card {
  @apply shadow-sm flex items-end justify-between py-12 px-10 rounded text-zinc-600
}

.card-name {
  @apply text-3xl font-medium
}

.card-value {
  @apply text-6xl font-medium
}
</style>