<template>
  <div class="layout-container">
    <HeaderComponent />

    <div class="content-wrapper">
      <SideBarComponent />
      <main>
        <slot />
      </main>
    </div>
  </div>
</template>

<script>
import HeaderComponent from '../components/HeaderComponent.vue'
import SideBarComponent from '../components/SideBarComponent.vue'

export default {
  components: {
    HeaderComponent,
    SideBarComponent
  }
}
</script>

<style scoped>
.layout-container {
  display: grid;
  grid-template-rows: 125px 1fr;
  height: 100vh;
}

.content-wrapper {
  display: grid;
  grid-template-columns: auto 1fr;
}

main {
  @apply px-3 py-5 sm:p-10 md:p-10 xl:p-10;
}

aside {
  z-index: 10;
}

@media screen and (max-width: 600px) {
  aside.closed+main {
    @apply opacity-100 pointer-events-auto;
  }

  aside:not([class*="closed"])+main {
    @apply opacity-0;
  }
}
</style>