<template>
  <BaseLayout>
    <RouterView />
  </BaseLayout>
</template>

<script>
import { RouterView } from 'vue-router'
import BaseLayout from './layouts/BaseLayout.vue'

export default {
  components: {
    BaseLayout,
    RouterView
  }
}
</script>

<style></style>