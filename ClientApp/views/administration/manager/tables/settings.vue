<template>
  <div class="p-3">
    <div class="table">
      <div class="text-center">{{this.editing ?'EDIT A TABLE' : 'ADD A TABLE'}}</div>
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
          <button class="purple-button" @click="confirm()">{{this.editing ? 'Edit' : 'Add'}}</button>
        </div>
      </div>
    </div>
    <div class="table mt-3">
      <div class="text-center">TABLES <icon class="cursor-pointer" icon='redo' @click="redo"/></div>
      <div class="flex-row">
        <div class="col-3 text-center">Table count</div>
        <div class="col-3 text-center">Table number</div>
        <div class="col-3 text-center">Seats count</div>
        <div class="col-3 flex-row justify-content-around">
          Editing
        </div>
      </div>
      <div class="flex-row" v-for="(table,index) in tables" :key="index">
        <div class="col-3 text-center">{{index+1}}</div>
        <div class="col-3 text-center">{{table.number}}</div>
        <div class="col-3 text-center">{{table.seatsCount}}</div>
        <div class="col-3 flex-row justify-content-around">
          <div class="cursor-pointer" @click="editTable(table)"><icon icon="pen"/></div>
          <div class="cursor-pointer" @click="deleteTable(table.tableId)"><icon icon="trash"/></div>
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
      },
      tables:[],
      editing:false
    }
  },
  methods:{
    confirm(){
      if(this.editing){
        this.$http.put('manager/table',this.table).then(response=>{
          alert(response.statusText)
          this.getTables();
        })
      }else{
        this.$http.post('manager/table',this.table).then(response=>{
          alert(response.statusText)
          this.getTables();
        })
      }
    },
    editTable(table){
      this.editing=true;
      this.table=JSON.parse(JSON.stringify(table));
    },
    deleteTable(index){
      this.$http.delete('manager/table/'+index);
      this.getTables();
    },
    redo(){
      this.table={};
      this.editing=false;
      this.getTables();
    },
    async getTables(){
      await this.$http.get('manager/tables/'+this.$store.state.editingRestaurant.restaurantId).then(response=>this.tables=response.data);
    }
  },
  created(){
    this.getTables();
  }
};
</script>