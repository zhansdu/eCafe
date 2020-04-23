<template>
  <div class="p-3">
    <div class="table">
      <div class="text-center">ADD A MANAGER</div>
      <div class="flex-column">
        <div class="flex-row">
          <div class="col-4">
            <input type="text" placeholder="Name" v-model="manager.firstName"/>
          </div>
          <div class="col-4">
            <input type="text" placeholder="Surname" v-model="manager.lastName">
          </div>
          <div class="col-4">
            <input type="text" placeholder="Phone number" v-model="manager.phoneNumber">
          </div>
        </div>
        <div class="flex-row">
          <div class="col-12 col-md-6">
            <input type="text" placeholder="Email" v-model="manager.email">
          </div>
          <div class="col-12 col-md-6">
            <input type="password" placeholder="Password" v-model="manager.password">
          </div>
        </div>
        <div class="flex-row justify-content-center">
          <button class="purple-button" @click="confirm()">Add</button>
        </div>
      </div>
    </div>
  </div>
</template>
<script type="text/javascript">
export default{
  data(){
    return{
      manager:{
        role:"manager"
      }
    }
  },
  methods:{
    confirm(){
      console.log(this.manager);
      this.$http.post('admin/manager',this.manager).then(response=>{
        alert(response.statusText)
      })
    }
  }
};
</script>
<style scoped>
  input{
    width: 100%;
  }
</style>