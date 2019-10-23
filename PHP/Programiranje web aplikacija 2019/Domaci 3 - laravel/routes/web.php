<?php


Route::get('/', 'UzorciController@index');
Route::get('/uzorci', 'UzorciController@index');
Route::post('/uzorci', 'UzorciController@store');
Route::get('/uzorci/create', 'UzorciController@create');
Route::put('/uzorci/{uzorak}','UzorciController@update');
Route::get('/uzorci/{uzorak}/edit','UzorciController@edit');
Route::delete('/uzorci/{uzorak}','UzorciController@destroy');

Route::post('/uzorci/{uzorak}','UzorciController@analize');

Route::get('/lab/create', 'LaboratorijaController@create');
Route::get('/lab', 'LaboratorijaController@index');
Route::post('/lab', 'LaboratorijaController@store');
Route::put('/lab/{lab}','LaboratorijaController@update');
Route::get('/lab/{lab}/edit','LaboratorijaController@edit');
Route::delete('/lab/{lab}','LaboratorijaController@destroy');

Route::get('/lab/analize', 'LaboratorijaController@analize');



