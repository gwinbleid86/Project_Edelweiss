﻿Feature: SearchClient
	Я, как пользователь системы денежных переводов, 
	могу делать поиск клиентов в БД.

@mytag
Scenario: Add two numbers
	Given Я нахожусь на главной странице приложения и я зарегистрирован(а) в роли "Админ"
	#//And И я зарегистрирован(а) в роли "Админ"
	When Я перехожу по ссылке поиск клиентов, ввожу номер паспорта
	Then И вижу список последних переводов клиента
