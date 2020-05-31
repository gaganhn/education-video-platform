<template>
  <div>
    <div class="jumbotron jumbotron-sm background-fix border">
      <div class="container">
        <div class="row">
          <div class="col-sm-12 col-lg-12">
            <h1 class="h1">Please select class and subject</h1>
          </div>
        </div>
      </div>
    </div>
    <el-card>
      <el-form
        :inline="true"
        ref="ruleForm"
        :model="formModel"
        class="demo-form-inline"
        size="medium"
      >
        <el-form-item label="Select Class:" prop="classSelection">
          <el-select v-model="formModel.classSelected" placeholder="Select Class">
            <el-option
              v-for="(value) in metaData"
              :key="value.name"
              :label="value.name"
              :value="value"
            ></el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="Select Subject" prop="subjectsSelected">
          <el-select v-model="formModel.subjectsSelected" placeholder="Select Subject">
            <el-option
              v-for="(value) in formModel.classSelected.subjects"
              :key="value.name"
              :label="value.name"
              :value="value"
            ></el-option>
          </el-select>
        </el-form-item>
        <el-form-item>
          <el-button type="primary" @click="submitForm()">Submit</el-button>
          <el-button @click="clear()">Clear</el-button>
        </el-form-item>
      </el-form>
    </el-card>
    <section class="mb-5">
      <div class="container">
        <div class="row title py-3">
          <div class="col-md-12">
            <h5>
              <strong>Video Lectures</strong>
            </h5>
          </div>
        </div>
        <div class="row">
          <div class="col-md-12">
            <div v-show="!formModel.subjectsSelected.lectures">No Lectures found!!!</div>
            <div
              class="row mb-3"
              v-for="(value, key) in formModel.subjectsSelected.lectures"
              :key="key">
              <div class="col-md-12">
                <div class="card">
                  <div class="card-body">
                    <div class="row">
                      <div class="col-md-3">
                        <img src="../../assets/video-thumbnail.png" />
                      </div>
                      <div class="col-md-7">
                        <h5>
                          Class {{formModel.classSelected.name}} - {{formModel.subjectsSelected.name}} - Lecture {{value.lectureid}}
                        </h5>
                        <!-- <small>Jopitor Inc., India</small>
                        <p>
                          <small>11907 Dyuuleves Incorpotatestion, South west, Newzealer</small>
                        </p> -->
                      </div>
                      <div class="col-md-2">
                        <router-link
                          :to="'/video/'+formModel.classSelected.name+'/'+formModel.subjectsSelected.name+'/'+value.lectureid"
                          v-slot="{ href, navigate }">
                          <a
                            class="btn btn-outline bg-orange"
                            :href="href"
                            @click="navigate"
                          >Watch Now!</a>
                        </router-link>
                        <!-- <button type="button" class="btn btn-outline bg-orange"></button> -->
                        <!-- <small>Published on Nov 27, 2017</small> -->
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
  </div>
</template>

<script src="./lectures-listing.js"></script>
<style scoped src="./lectures-listing.css"></style>