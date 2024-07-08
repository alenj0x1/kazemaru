<template>
  <aside ref="aside">
    <div class="w-full">
      <button ref="manageSidebar" @click="manageSidebar">{{ '<' }}</button>
    </div>

    <!-- Projects -->
    <div ref="projectsContainer">
      <strong>Projects</strong>

      <ul>
        <li>Project #1</li>
        <li>Project #2</li>
        <li>Project #3</li>
        <li>Project #4</li>
      </ul>
    </div>
  </aside>
</template>

<script lang="ts">
export default {
  name: 'SideBarComponent',
  methods: {
    manageSidebar() {
      const aside = this.$refs.aside as HTMLElement;
      const manageSidebar = this.$refs.manageSidebar as HTMLButtonElement;
      const projectsContainer = this.$refs.projectsContainer as HTMLDivElement;

      if (!aside.classList.contains('closed')) {
        manageSidebar.textContent = '>'
        aside.classList.add('closed')
        projectsContainer.classList.add('hidden')
      }
      else {
        manageSidebar.textContent = '<'
        aside.classList.remove('closed')
        projectsContainer.classList.remove('hidden')
      }
    }
  }
}
</script>

<style scoped>
aside {
  @apply border-slate-100 border-x-2 px-2 py-4 flex flex-col items-start w-56 transition-all gap-2 max-w-full h-screen bg-white
}

button {
  @apply bg-blue-500 p-2 rounded text-white w-full font-bold
}

.closed {
  @apply w-16 transition-all
}

div {
  @apply transition-all
}

strong {
  @apply text-2xl font-normal text-zinc-800
}

@media screen and (max-width: 600px) {
  aside {
    @apply w-screen
  }

  aside:not([class*="closed"]) {
    @apply absolute
  }
}
</style>