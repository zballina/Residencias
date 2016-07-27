/*
 * Licensed to the Apache Software Foundation (ASF) under one
 * or more contributor license agreements.  See the NOTICE file
 * distributed with this work for additional information
 * regarding copyright ownership.  The ASF licenses this file
 * to you under the Apache License, Version 2.0 (the
 * "License"); you may not use this file except in compliance
 * with the License.  You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied.  See the License for the
 * specific language governing permissions and limitations
 * under the License.
 */

function Moodle() {
    this.get_users = function () {
        $.ajax({
            url: 'https://www.moodle.itsescarcega.edu.mx/webservice/rest/server.php?',
            data: {
                wstoken: 'd16a1af9a32156b7a6dd30c43daad555',
                wsfunction: 'core_user_get_users',
                moodlewsrestformat: 'json',
                criteria : 
                    {
                        0: {
                            key: 'fullname',
                            value: '%'
                        }
                    },
                }
        }).success(function (response) {
            var select = $('#idselectusers');
            var ul = $('.dropdown-menu.inner');
            select.empty();
            ul.empty();
            for (var i = 0; i < response.users.length; i++) {
                var option = $('<option value="' + response.users[i].username + '">' + response.users[i].fullname + '</option>');
                var li = $('<li data-original-index="' + i + '" class=""><a tabindex="' + i + '" class="" style="" data-tokens="null"><span class="text">' + response.users[i].fullname + '</span><span class="glyphicon glyphicon-ok check-mark"></span></a></li>');

                select.append(option);
                ul.append(li);
            }
            alert("Listo");
        });
    };
}

moodle = new Moodle();
