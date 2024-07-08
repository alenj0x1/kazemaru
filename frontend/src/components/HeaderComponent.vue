<template>
  <header>
    <div>
      <h1 class="kazemaru">kazemaru</h1>
      <span>your personal project manager</span>
    </div>
  </header>
</template>

<script>
export default {
  name: 'HeaderComponent'
}
</script>

<style scoped>
header {
  @apply p-8 shadow
}

div {
  @apply flex flex-col
}

h1 {
  @apply text-3xl font-semibold
}

span {
  @apply text-sm text-zinc-500
}
</style>