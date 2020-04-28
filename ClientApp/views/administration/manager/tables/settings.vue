<template>
  <div class="p-3">
    <div class="table">
      <div class="text-center">ADD A TABLE</div>
      <div class="flex-column">
        <div class="flex-row">
          <div class="col-6">
            <input type="number" placeholder="Number" v-model="table.number"/>
          </div>
          <div class="col-6">
            <input type="number" placeholder="Seats count" v-model="table.seatsCount">
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
      table:{
        restaurantId:this.$store.state.editingRestaurant.restaurantId
      }
    }
  },
  methods:{
    confirm(){
      this.$http.post('manager/table',this.table).then(response=>{
        alert(response.statusText)
      })
    }
  }
};
</script>