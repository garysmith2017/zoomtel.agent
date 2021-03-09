
Vue.component('zt-select', {
    data: function () {
        return {
            value:'',
            items:[]
        }

    },
    props: ['url'],
    template: `
<div>

   <el-select v-model='value'>
<el-option v-for='item in items' :label='item.label' :value='item.value'></el-option>
   </el-select>
</div>
  `,
    created: function () {
        this.getData();
    },
    methods: {
        getData: function () {
            var that = this;
            request.get(that.url).then(function (res) {
                that.items = res.data;
            });


        }


    }
}
   

)