import { defineStore } from 'pinia'
import { ref, type Ref, type UnwrapRef } from 'vue'

export const useProjectsStore = defineStore('projects', () => {
  const projects: Ref<UnwrapRef<any[]>> = ref([])

  function setProjects(newProjects: any[]) {
    projects.value = newProjects
  }

  return { projects, setProjects }
})
