<template>
    <section style="background-color: #eee;">
  <div class="container py-4">
    <div style="text-align: center;"><h1 style="font-weight: bold;">Update Profile</h1><br></div>
    <div class="row">
      <div class="col-lg-4">
      
        <div class="card mb-4">
          <div class="card-body" style="text-align: center;">
            <form @submit.prevent="handleSummitPersonal" :id="personal">
            <div class="row">
              <div class="col-sm-3">
                <p class="mb-0" style="font-weight: bold;">Email</p>
              </div>
              <div class="col-sm-9" >
                <input type="text" :value="user.Email" readonly/>
              </div>
            </div>
            <hr>
            
              <div class="row">
                <div class="col-sm-3">
                  <p class="mb-0" style="font-weight: bold;">Phone</p>
                </div>
                <div class="col-sm-9" >
                  <input id="PhoneUser" v-if="user.Personal != null && user.Personal.Phone!=null" :value="user.Personal.Phone"/>
                  <input id="PhoneUser" v-else/>
                </div>
              </div>
              
              <hr>
              <div class="row">
                <div class="col-sm-3">
                  <p class="mb-0" style="font-weight: bold;">Address</p>
                </div>
                <div class="col-sm-9" >
                  <input id="AddressUser" v-if="user.Personal !=null && user.Personal.Address!=null" :value="user.Personal.Address"/>
                  <input id="AddressUser" v-else/>
                </div>
              </div>
              <hr>
              <div class="row" >
                <div class="col-sm-3">
                  <p class="mb-0" style="font-weight: bold;">Birthday</p>
                </div>
                <div class="col-sm-9">
                  <input v-if="user.Personal !=null && user.Personal.Birthday!=null" type="date" min="1900-01-01" max="2005-12-31"  :value="user.Personal.Birthday" readonly/>
                  <input id="dateUser" v-else type="date" min="1900-01-01" max="2005-12-31"/>
                </div>
              </div>
            </form>
            <div style="display: flex; justify-content: center;" >
              <Button @click="handleSummitPersonal" :form="personal" :variant="primary" :type="submit" class="btn btn-primary mt-3 mw-25 " ><a  style="color: white; text-decoration: none !important;">Save</a> </Button>
            </div>
            
          </div>
        </div>       
      </div>
      
      <div class="col-lg-8">
        <div class="row">
          <div class="md-6" >
            <div class="card mb-4 mb-md-0">
              <div class="card-body">
                <p class="mb-4" style="font-weight: bold; text-align: center;"> Hobbies </p>
                <p class="mb-4" style="font-weight: bold; text-align: center;" > Sport </p>
                <div class="row">
                  <div class="col-6">
                    <div v-for="index in sport" style="display: inline-block; width: 30%; margin: 5px; text-align: right: inherit;;">
                      <input type="checkbox" :id="index" :value="index" v-model="sportSelect">
                      <label :for="index"> {{index}}</label>
                    </div>
                  </div>
                  <div class="col-6">
                    <div class="card bg-light mb-3">
                      <div class="card-header" style="text-align: center;">Deportes seleccionados</div>
                      <ul>
                        <div v-for="index in sportSelect">
                          <li>{{ index }}</li>
                        </div>
                      </ul>
                    </div>
                  </div>
                </div>
                <hr>
                <p class="mb-4" style="font-weight: bold; text-align: center;" > Literature </p>
                <div class="row">
                  <div class="col-sm-8">
                    <div class="card bg-light mb-3">
                      <div class="card-header" style="text-align: center;">Libros registrados</div>
                      <ol>
                        <div v-for="index in literatureSelect">
                          <li>{{ index }} <button  @click="this.literatureSelect.indexOf(index) > -1 ? this.literatureSelect.splice(index,1) : null" style="display: inline; background-color: rgba(255, 255, 255, 0.1); border: none; "><i id="buttonIdNameIcon" class="bi bi-trash"></i></button></li>
                          
                        </div>
                      </ol>
                    </div>
                  </div>
                  <div class="col">
                    
                      <div>
                        <textarea class="example-default-value" placeholder="Type here"
                        id="literature"></textarea>
                      </div>
                      <div>
                        <input type="button" value="Agregar"
                        @click="example_append('literature')" />
                      </div>
                    
                  </div>
                </div>
                <hr>
                <p class="mb-4" style="font-weight: bold; text-align: center;" > Food </p>
                <div class="row">
                  <div class="col-sm-8">
                    <div class="card bg-light mb-3">
                      <div class="card-header" style="text-align: center;">Comida registrada</div>
                      <ol>
                        <div v-for="index in foodSelect">
                          <li>{{ index }} <button  @click="this.foodSelect.indexOf(index) > -1 ? this.foodSelect.splice(index,1) : null" style="display: inline; background-color: rgba(255, 255, 255, 0.1); border: none; "><i id="buttonIdNameIcon" class="bi bi-trash"></i></button></li>
                        </div>
                      </ol>
                    </div>
                  </div>
                  <div class="col">
                    
                      <div>
                        <textarea class="example-default-value" placeholder="Type here"
                        id="food"></textarea>
                      </div>
                      <div>
                        <input type="button" value="Agregar"
                        @click="example_append('food')" />
                      </div>
                    
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
  <div style="display: flex; justify-content: center;" >
    <Button variant="primary" class="mt-3 mw-25"><a href="/user/data" style="color: white; text-decoration: none !important;">Edit <i class="bi bi-pencil-square"></i></a> </Button>
  </div>
</section>
</template>
<script>

import InputItem from '../../../atoms/InputItem/InputItem.vue'
import Button from '../../../atoms/Button/Button.vue'
import PItem from '../../../atoms/PItem/PItem.vue'
import ErrorData from '../../../atoms/ErrorData/ErrorData.vue'
import {mapGetters } from 'vuex'
import { ref } from 'vue';
import axios from 'axios'

export default {
    name: 'User',
    
    components: {
        Button,
        PItem,
        InputItem,
        ErrorData
    },
    setup(){
      const sport = ref(["Baloncesto", "Tenis", "Futbol", "Beisbol","Golf","Voleibol","Cicismo","Rugby","Natacion", "GYM"])
      const sportSelect = ref([]);
      const literatureSelect = ref([]);
      const foodSelect = ref([]);
      return {
        sport,
        sportSelect,
        literatureSelect,
        foodSelect
        
      };
    },
    mounted: function(){
      JSON.parse(this.user.Hobbies.Sport).Activity.forEach(element => {
        this.sportSelect.push(element);
      });
      JSON.parse(this.user.Hobbies.Literature).Books.forEach(element => {
        this.literatureSelect.push(element);
      });
      JSON.parse(this.user.Hobbies.Foods).FavoriteFood.forEach(element => {
        this.foodSelect.push(element);
      });
    },
    computed:{
        ...mapGetters(['user'])
    },
    methods:{
      example_append(args) {
          if(args === 'literature'){
            let textInput = document.getElementById('literature');

            if(textInput.value !== ""){
                this.literatureSelect.push(textInput.value);
                textInput.value="";
              }
          }
          if(args ==='food'){
            let textInput = document.getElementById('food');

            if(textInput.value !== ""){
                this.foodSelect.push(textInput.value);
                textInput.value="";
              }
          }
          
        },
      async handleSummitPersonal(){
        console.log(this);
        
        }
    }
};
</script>
<style></style>