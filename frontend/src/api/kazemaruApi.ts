import axios from 'axios'

const kazemaruApi = axios.create({
  baseURL: 'http://localhost:5000/api'
})

export default kazemaruApi
