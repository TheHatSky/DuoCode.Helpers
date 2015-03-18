function PostAddressClass() {
	// Константы
	var quickMode = "quick";
	var selectMode = "select";
	var customMode = "custom";

	this.host = "";

	this.isDictionaryInitialized = false;

	this.countryId = "@empty";
	this.regionId = "@empty";
	this.districtId = "@empty";
	this.settlementId = "@empty";
	this.settlementName = "";
	this.settlementTypeId = "@empty";
	this.streetTypeId = "@empty";

	this.dictionaryLoadCallback;
	this.dictionaryBeforeLoadCallback;

	// jQuery селекторы
	this.complexSettlementInputSwitchClass = ".complex-settlement-input-switch";
	this.simpleSettlementInputSwitchClass = ".simple-settlement-input-switch";
	this.simpleSettlementInputTypePanelClass = ".simple-settlement-input-panel";
	this.simpleSettlementStructuredLabelClass = ".simple-settlement-structured-label";
	this.simpleSettlementUnstructuredLabelClass = ".simple-settlement-unstructured-label";
	this.complexSettlementInputTypePanelClass = ".complex-settlement-input-panel";
	this.simpleSettlementInputTextBoxClass = ".simple-settlement-input-textbox";
	this.postIndexTextBoxClass = ".postindex-textbox";
	this.isAddressStructuredFieldClass = ".is-address-structured-field";
	this.settlementInputModeFieldClass = ".settlement-input-mode-field";
	this.countrySelectorClass = "select.country-selector";
	this.regionSelectorClass = "select.region-selector";
	this.districtSelectorClass = "select.district-selector";
	this.settlementSelectorClass = "select.settlement-selector";
	this.settlementTextBoxClass = ".settlement-textbox";
	this.settlementTypeSelectorClass = "select.settlement-type-selector";
	this.settlementSelectorPanelClass = ".settlement-selector-panel";
	this.settlementTextBoxPanelClass = ".settlement-textbox-panel";
	this.settlementEnterModeToSelectorSwitchClass = ".settlement-enter-mode-to-selector-switch";
	this.streetTextboxClass = ".street-textbox";
	this.streetTypeSelectorClass = "select.street-type-selector";
	this.houseTextBoxClass = ".house-textbox";
	this.houseSwitchClass = ".house-switch";
	this.estateSwitchClass = ".estate-switch";
	this.isEstateHiddenFieldClass = ".is-estate-hidden";
	this.housePanelClass = ".house-panel";
	this.estatePanelClass = ".estate-panel";
	this.buildingTextBoxClass = ".building-textbox";
	this.unitTextBoxClass = ".unit-textbox";
	this.flatTextBoxClass = ".flat-textbox";
	this.line1TextBoxClass = ".line1-textbox";
	this.line2TextBoxClass = ".line2-textbox";
	this.fullAddressLabelClass = ".full-address-label";
	this.structuredAddressPanelClass = ".structured-address-panel";
	this.unstructuredAddressPanelClass = ".unstructured-address-panel";

	this.flatSwitchClass = ".flat-switch";
	this.officeSwitchClass = ".office-switch";
	this.isOfficeHiddenFieldClass = ".is-estate-hidden";
	this.flatPanelClass = ".flat-panel";
	this.officePanelClass = ".office-panel";

	// Контролы
	var _flatSwitch = null;
	var _officeSwitch = null;
	var _isOfficeHiddenField = null;
	var _flatPanel = null;
	var _officePanel = null;

	var _houseSwitch = null;
	var _estateSwitch = null;
	var _isEstateHiddenField = null;
	var _housePanel = null;
	var _estatePanel = null;
	var _buildingTextBox = null;
	var _unitTextBox = null;
	var _flatTextBox = null;
	var _fullAddressLabel = null;
	var _complexSettlementInputSwitch = null;
	var _quickSettlementInputSwitch = null;
	var _simpleSettlementInputTypePanel = null;
	var _simpleSettlementStructuredLabel = null;
	var _simpleSettlementUnstructuredLabel = null;
	var _complexSettlementInputTypePanel = null;
	var _quickSettlementInputTextBox = null;
	var _postIndexInput = null;
	var _countrySelector = null;
	var _regionSelector = null;
	var _districtSelector = null;
	var _isAddressStructuredField = null;
	var _settlementInputModeField = null;
	var _settlementSelector = null;
	var _customSettlementTextBox = null;
	var _settlementTypeSelector = null;
	var _settlementSelectorPanel = null;
	var _settlementTextBoxPanel = null;
	var _switchSettlementInputModeToSelector = null;
	var _streetTextBox = null;
	var _streetTypeSelector = null;
	var _houseTextBox = null;
	var _line1TextBox = null;
	var _line2TextBox = null;
	var _structuredAddressPanel = null;
	var _unstructuredAddressPanel = null;

	// Вспомогательные переменные
	var _this = this;
	var _initialized = false;
	var _updating = false;
	var _isAddressStructured = true;
	var _activeMode = selectMode;

	// Поля необходимые для отображения полного адреса в одной строке
	var _regionNameForFullAdress = null;
	var _districtNameForFullAdress = null;
	var _isEstate = false;
	var _isOffice = false;

	///////////////////
	// Private methods
	///////////////////

	function _startsWith(str, s) {
		return typeof (str) === 'string' && str.indexOf(s) === 0;
	};

	function _isEmpty(str) {
		return str == null || str === '' || _startsWith(str, "@empty");
	};

	function _isDelimiter(str) {
		return str == null || _startsWith(str, "@delimiter");
	};

	function _isEmptyOrDelimiter(str) {
		return _isEmpty(str) || _isDelimiter(str);
	};

	function _isOther(str) {
		return str == null || _startsWith(str, "@other");
	};

	function _isEmptyOrDelimiterOrOther(str) {
		return _isEmpty(str) || _isDelimiter(str) || _isOther(str);
	};

	function _getSelectedText(selector) {
		if (_isEmptyOrDelimiterOrOther(selector.val())) {
			return null;
		} else {
			var text = selector.children("option:selected").text();
			return text === "" ? null : text;
		}
	};

	function _fillSelect(select, data) {
		select.empty();

		$.each(data, function (index, domObject) {
			var option = $("<option></option>").attr("value", domObject.value).text(domObject.text);
			if (!domObject.selectable)
				option.attr("disabled", "disabled");
			select.append(option);
		});
	};

	function _setSelectedItem(select, selectedItem) {
		try {
			select.val(selectedItem);
			select.trigger("change", true);
		} catch (ex) {
			setTimeout("$('#" + select.attr('id') + "').val('" + selectedItem + "')", 1);
		}
	};

	function _getPostIndex() {
		var postIndex = $.trim(_postIndexInput.val());
		return postIndex === "" ? null : postIndex;
	};

	function _setPostIndex(postIndex) { _postIndexInput.val(postIndex); };

	function _getSelectedCountryId() {
		return _countrySelector.length != 0 ? _countrySelector.val() : _this.countryId;
	};

	function _getSelectedCountryName() { return _getSelectedText(_countrySelector); };

	function _selectCountryById(countryId) {
		_this.countryId = countryId;
		_setSelectedItem(_countrySelector, countryId);
	};

	function _fillCountriesList(options) { _fillSelect(_countrySelector, options); };

	function _getSelectedRegionId() { return _regionSelector.val(); };

	function _getSelectedRegionName() { return _getSelectedText(_regionSelector); };

	function _selectRegionById(regionId) { _setSelectedItem(_regionSelector, regionId); };

	function _fillRegionsList(options) { _fillSelect(_regionSelector, options); };

	function _getSelectedDistrictId() { return _districtSelector.val(); };

	function _getSelectedDistrictName() { return _getSelectedText(_districtSelector); };

	function _selectDistrictById(districtId) { _setSelectedItem(_districtSelector, districtId); };

	function _fillDistrictsList(options) { _fillSelect(_districtSelector, options); };

	function _getSelectedSettlementId() { return _settlementSelector.val(); };

	function _getSelectedSettlementName() { return _getSelectedText(_settlementSelector); };

	function _getSelectedSettlementTypeId() { return _settlementTypeSelector.val(); };

	function _getIsEstateValue() {
		if (_isEstateHiddenField != null)
			return _isEstateHiddenField.val();
		else return _isEstate;
	}

	function _getSelectedSettelmentTypeName() {
		var settelmentTypeName = _getSelectedText(_settlementTypeSelector);
		if (settelmentTypeName != null) {
			settelmentTypeName = settelmentTypeName.toLowerCase();
		}
		return settelmentTypeName;
	};

	function _selectSettelmentTypeById(settelmentTypeId) {
		_setSelectedItem(_settlementTypeSelector, settelmentTypeId);
	};

	function _selectSettlementById(settlementId) { _setSelectedItem(_settlementSelector, settlementId); };

	function _setCustomSettlementName(settlement) {
		_customSettlementTextBox.val(settlement);
	};

	function _getSettlementName() {
		var settelmentName = _customSettlementTextBox.val();
		if (settelmentName === "") {
			settelmentName = null;
		}
		if (settelmentName == null) {
			settelmentName = _getSelectedSettlementName();
		}
		return settelmentName;
	};

	function _getTextForQuickInput() {
		var postIndex = _getPostIndex();
		var settlement = _getSettlementName();
		if (!_getIsAddressStructured() || postIndex == null) {
			return settlement;
		}
		else if (settlement == null) {
			return postIndex;
		} else {
			return postIndex + ", " + settlement;
		}
	};

	function _getIsAddressStructured() {
		return _isAddressStructured;
	}

	function _setIsAddressStructured(isAddressStructured) {
		_isAddressStructured = isAddressStructured;
		_isAddressStructuredField.val(isAddressStructured);
		if (_isAddressStructured) {
			_simpleSettlementStructuredLabel.show();
			_simpleSettlementUnstructuredLabel.hide();
			_structuredAddressPanel.show();
			_unstructuredAddressPanel.hide();
		}
		else {
			_simpleSettlementStructuredLabel.hide();
			_simpleSettlementUnstructuredLabel.show();
			_structuredAddressPanel.hide();
			_unstructuredAddressPanel.show();
		}
		_updateFullAddress();
	}

	function _isSettlementInputModeSaved() {
		return _settlementInputModeField.length != 0 && _settlementInputModeField.val() != "";
	}

	function _isQuickSettlementInputModeAvailable() {
		return _quickSettlementInputTextBox.length != 0;
	}

	function _getSettlementInputMode() {
		return _isSettlementInputModeSaved() ? _settlementInputModeField.val().toLowerCase() : _activeMode;
	}

	function _setSettlementInputMode(mode) {
		var previousMode = _getSettlementInputMode();
		_settlementInputModeField.val(mode);
		_activeMode = mode;
		switch (_activeMode) {
			case quickMode:
				if (_isEmpty(_getSelectedSettlementId())) {
					_clearSelectedSettlement();
				}
				break;
			case selectMode:
				_showSelectSettlementInput();
				if (previousMode == quickMode) {
					_clearQuickSettlementIfNecessary();
					if (!!_customSettlementTextBox.val() && !!_settlementTypeSelector.val()) {
						_showCustomSettlementInput();
						_activeMode = customMode;
					}
				} else if (previousMode == customMode) {
					_clearCustomSettlement();
					_selectSettlementById("@empty");
				}
				break;
			case customMode:
				if (previousMode == quickMode) {
					_clearQuickSettlementIfNecessary();
				}
				_showCustomSettlementInput();
				break;
		}
	}

	function _clearQuickSettlementIfNecessary() {
		if (_quickSettlementInputTextBox.val() != _getTextForQuickInput()) {
			_quickSettlementInputTextBox.val(null);
		}
	}

	function _clearSelectedSettlement() {
		_setPostIndex(null);
		_selectSettlementById("@empty");
		_selectDistrictById("@empty");
		_selectRegionById("@empty");
		_clearCustomSettlement();
		_clearQuickSettlementIfNecessary();
	}

	function _clearCustomSettlement() {
		_setCustomSettlementName(null);
	}

	function _showQuickSettlementInput() {
		_complexSettlementInputTypePanel.hide();
		_simpleSettlementInputTypePanel.show();
	}

	function _showComplexSettlementInput() {
		_complexSettlementInputTypePanel.show();
		_simpleSettlementInputTypePanel.hide();
	}

	function _showSelectSettlementInput() {
		_settlementSelectorPanel.show();
		_settlementTextBoxPanel.hide();
	}

	function _showCustomSettlementInput() {
		_settlementSelectorPanel.hide();
		_settlementTextBoxPanel.show();
	}

	function _fillSettlementsList(options) { _fillSelect(_settlementSelector, options); }

	function _setFocusToStreetTextBox() { _streetTextBox.focus(); };

	function _getStreet() {
		var street = _streetTextBox.val();
		return street === "" ? null : street;
	};

	function _setStreet(street) { _streetTextBox.val(street); };

	function _getStreetTypeName() {
		var streetTypeName = _getSelectedText(_streetTypeSelector);
		if (streetTypeName != null) {
			streetTypeName = streetTypeName.toLowerCase();
		}
		return streetTypeName;
	};

	function _selectStreetTypeById(streetTypeId) {
		// Пункта "Выберите тип улицы" нет, поэтому всегда должен быть выбран какой нибудь тип улицы
		if (streetTypeId != null) {
			_setSelectedItem(_streetTypeSelector, streetTypeId);
		}
	};

	function _setFocusToHouse() { _houseTextBox.focus(); };

	function _getHouse() {
		var house = _houseTextBox.val();
		return house === "" ? null : house;
	};

	function _getUnit() {
		var unit = _unitTextBox.val();
		return unit === "" ? null : unit;
	};

	function _getBuilding() {
		var building = _buildingTextBox.val();
		return building === "" ? null : building;
	};

	function _getFlat() {
		var flat = _flatTextBox.val();
		return flat === "" ? null : flat;
	};

	function _getLine1() {
		var line1 = _line1TextBox.val();
		return line1 === "" ? null : line1;
	};

	function _getLine2() {
		var line2 = _line2TextBox.val();
		return line2 === "" ? null : line2;
	};

	function _initControls() {
		_complexSettlementInputSwitch = $(_this.complexSettlementInputSwitchClass);
		_quickSettlementInputSwitch = $(_this.simpleSettlementInputSwitchClass);
		_simpleSettlementInputTypePanel = $(_this.simpleSettlementInputTypePanelClass);
		_simpleSettlementStructuredLabel = $(_this.simpleSettlementStructuredLabelClass);
		_simpleSettlementUnstructuredLabel = $(_this.simpleSettlementUnstructuredLabelClass);
		_complexSettlementInputTypePanel = $(_this.complexSettlementInputTypePanelClass);
		_quickSettlementInputTextBox = $(_this.simpleSettlementInputTextBoxClass);
		_postIndexInput = $(_this.postIndexTextBoxClass);
		_countrySelector = $(_this.countrySelectorClass);
		_regionSelector = $(_this.regionSelectorClass);
		_districtSelector = $(_this.districtSelectorClass);
		_isAddressStructuredField = $(_this.isAddressStructuredFieldClass);
		_settlementInputModeField = $(_this.settlementInputModeFieldClass);
		_settlementSelector = $(_this.settlementSelectorClass);
		_customSettlementTextBox = $(_this.settlementTextBoxClass);
		_settlementTypeSelector = $(_this.settlementTypeSelectorClass);
		_settlementSelectorPanel = $(_this.settlementSelectorPanelClass);
		_settlementTextBoxPanel = $(_this.settlementTextBoxPanelClass);
		_switchSettlementInputModeToSelector = $(_this.settlementEnterModeToSelectorSwitchClass);
		_streetTextBox = $(_this.streetTextboxClass);
		_streetTypeSelector = $(_this.streetTypeSelectorClass);
		_houseTextBox = $(_this.houseTextBoxClass);
		_houseSwitch = $(_this.houseSwitchClass);
		_estateSwitch = $(_this.estateSwitchClass);
		_isEstateHiddenField = $(_this.isEstateHiddenFieldClass);
		_housePanel = $(_this.housePanelClass);
		_estatePanel = $(_this.estatePanelClass);
		_buildingTextBox = $(_this.buildingTextBoxClass);
		_unitTextBox = $(_this.unitTextBoxClass);
		_flatTextBox = $(_this.flatTextBoxClass);
		_line1TextBox = $(_this.line1TextBoxClass);
		_line2TextBox = $(_this.line2TextBoxClass);
		_fullAddressLabel = $(_this.fullAddressLabelClass);
		_structuredAddressPanel = $(_this.structuredAddressPanelClass);
		_unstructuredAddressPanel = $(_this.unstructuredAddressPanelClass);

		_flatSwitch = $(_this.flatSwitchClass);
		_officeSwitch = $(_this.officeSwitchClass);
		_isOfficeHiddenField = $(_this.isOfficeHiddenFieldClass);
		_flatPanel = $(_this.flatPanelClass);
		_officePanel = $(_this.officePanelClass);
	}

	function _initPostIndex() {
		if (_postIndexInput.length > 0) {
			var autocompleteElement = _postIndexInput.autocomplete({
				source: function (request, response) {
					if (_this.isDictionaryInitialized && _getIsAddressStructured()) {
						$.itcJsonp({
							url: _this.host + "/v1/postaddress/autocomplete/simplesettlements/for-country/" + _getSelectedCountryId(),
							data: {
								searchValue: request.term
							},
							success: function (data) {
								var i = 0;
								response($.map(data, function (item) {
									return {
										alt: i++,
										label: item.postIndex,
										desc: item.description + " " + item.settlementName,
										settlementId: item.settlementId,
										settlementName: item.settlementName,
										regionName: item.regionName,
										districtName: item.districtName,
										postIndex: item.postIndex,
										streetName: item.streetName,
										streetTypeId: item.streetTypeId
									};
								}));
							}
						});
					}
					else {
						response();
					}
				},
				minLength: 6,
				// событие change вызывается, только если пользователь не воспользовался autocomplete'ом
				change: function () {
					if (_getSettlementInputMode() == quickMode) {
						_setSettlementInputMode(selectMode);
					}
					_updateFullAddress();
				},
				select: function (event, ui) {
					if (ui.item.postIndex != null) {
						_setPostIndex(ui.item.postIndex);
						_selectStreetTypeById(ui.item.streetTypeId);
						_setStreet(ui.item.streetName);
						_loadDictionariesBySettlementIdAndPostIndex(ui.item.settlementId, ui.item.postIndex);
					}
					else {
						_loadDictionariesBySettlementId(ui.item.settlementId, false);
					}
					_setFocusToStreetTextBox();
					_updateFullAddress();
				},
				open: function () {
				},
				close: function () {
				}
			});

			if (typeof autocompleteElement.data("autocomplete") == "undefined") {
				if (typeof autocompleteElement.data("ui-autocomplete") == "undefined") {
					autocompleteElement = autocompleteElement.data("uiAutocomplete");
				} else {
					autocompleteElement = autocompleteElement.data("ui-autocomplete");
				}
			} else {
				autocompleteElement = autocompleteElement.data("autocomplete");
			}

			autocompleteElement._renderItem = function (ul, item) {
				return $("<li class='ui-autocomplete-popup'></li>")
					.data("item.autocomplete", item)
					.append("<a>" +
						"<div class='ui-autocomplete-item-label'>" + item.label + "</div>" +
						"<div class='ui-autocomplete-item-desc'>" + item.desc + "</div>" + "</a>")
					.appendTo(ul);
			};
		}
	};

	function _initCountry() {
		_countrySelector.bind("change", function (e, isFake) {
			if (!isFake && !_updating)
				_this.onCountryChanged();
			return false;
		});
	}

	function _initRegion() {
		_regionSelector.bind("change", function (e, isFake) {
			if (!isFake && !_updating)
				_this.onRegionChanged();
			return false;
		});
	}

	function _initDistrict() {
		_districtSelector.bind("change", function (e, isFake) {
			if (!isFake && !_updating)
				_this.onDistrictChanged();
			return false;
		});
	}

	function _initSettlement() {
		_settlementSelector.change(function (e, isFake) {
			if (!isFake && !_updating) {
				_this.onSettlementIdChanged();
			}
			_updateFullAddress();
			return false;
		});

		_switchSettlementInputModeToSelector.click(function () {
			_setSettlementInputMode(selectMode);
			return false;
		});

		_complexSettlementInputSwitch.click(function () {
			_setSettlementInputMode(selectMode);
			_showComplexSettlementInput();
			return false;
		});

		_quickSettlementInputSwitch.click(function () {
			_setSettlementInputMode(quickMode);
			_showQuickSettlementInput();
			return false;
		});

		_customSettlementTextBox.change(function () {
			_quickSettlementInputTextBox.val(_getTextForQuickInput());
			_updateFullAddress();
		});

		_settlementTypeSelector.change(_updateFullAddress);

		if (_settlementSelector.hasClass("input-validation-error") ||
			_regionSelector.hasClass("input-validation-error") ||
			_districtSelector.hasClass("input-validation-error")) {
			_quickSettlementInputTextBox.addClass("input-validation-error");
		}

		_quickSettlementInputTextBox.focus(function () {
			if (_getPostIndex() != null && _getSettlementName() != null) {
				_quickSettlementInputTextBox.val("");
			}
		});

		_quickSettlementInputTextBox.blur(function () {
			if (_getPostIndex() != null && _getSettlementName() != null && _quickSettlementInputTextBox.val() == "") {
				_quickSettlementInputTextBox.val(_getTextForQuickInput());
			}
		});

		if (_quickSettlementInputTextBox.length > 0) {
			var autocompleteElement = _quickSettlementInputTextBox.autocomplete({
				source: function (request, response) {
					if (_this.isDictionaryInitialized) {
						jQuery.itcJsonp({
							url: _this.host + "/v1/postaddress/autocomplete/simplesettlements/for-country/" + _getSelectedCountryId(),
							data: {
								searchValue: request.term
							},
							success: function (data) {
								var i = 0;
								response($.map(data, function (item) {
									var label = item.settlementName;
									if (item.postIndex != null) {
										label = item.postIndex + ", " + label;
									}
									return {
										alt: i++,
										label: label,
										desc: item.description,
										settlementId: item.settlementId,
										settlementName: item.settlementName,
										regionName: item.regionName,
										districtName: item.districtName,
										postIndex: item.postIndex,
										streetName: item.streetName,
										streetTypeId: item.streetTypeId
									};
								}));
							}
						});
					} else {
						response();
					}
				},
				minLength: 3,
				// событие change вызывается, только если пользователь не воспользовался autocomplete'ом
				change: function () {
					// Эта проверка нужна, чтобы автозаполнение не вызывалось, если пользователь ничего не изменял.
					if (_quickSettlementInputTextBox.val() != _getTextForQuickInput()) {
						_this.onSimpleSettlementChanged();
					}
				},
				select: function (event, ui) {
					if (ui.item.postIndex != null) {
						_setPostIndex(ui.item.postIndex);
						_selectStreetTypeById(ui.item.streetTypeId);
						_setStreet(ui.item.streetName);
						_loadDictionariesBySettlementIdAndPostIndex(ui.item.settlementId, ui.item.postIndex);
					}
					else {
						_loadDictionariesBySettlementId(ui.item.settlementId), false;
					}
					_setFocusToStreetTextBox();
				},
				open: function () {
				},
				close: function () {
				}
			});

			if (typeof autocompleteElement.data("autocomplete") == "undefined") {
				if (typeof autocompleteElement.data("ui-autocomplete") == "undefined") {
					autocompleteElement = autocompleteElement.data("uiAutocomplete");
				} else {
					autocompleteElement = autocompleteElement.data("ui-autocomplete");
				}
			} else {
				autocompleteElement = autocompleteElement.data("autocomplete");
			}

			autocompleteElement._renderItem = function (ul, item) {
				return $("<li class='ui-autocomplete-popup'></li>")
					.data("item.autocomplete", item)
					.append("<a>" +
						"<div class='ui-autocomplete-item-label'>" + item.label + "</div>" +
						"<div class='ui-autocomplete-item-desc'>" + item.desc + "</div>" + "</a>")
					.appendTo(ul);
			};
		}

		_customSettlementTextBox.autocomplete({
			source: function (request, response) {
				if (_this.isDictionaryInitialized) {
					var query = {
						postIndex: _getPostIndex(),
						searchValue: request.term
					};

					if (!_isEmptyOrDelimiter(_getSelectedDistrictId()))
						query.districtId = _getSelectedDistrictId();
					else
						query.regionId = _getSelectedRegionId();

					jQuery.itcJsonp({
						url: _this.host + "/v1/postaddress/autocomplete/settlements",
						data: query,
						success: function (data) {
							response($.map(data, function (item) {
								return {
									label: item.text,
									value: item.text,
									id: item.value
								};
							}));
						}
					});
				} else {
					response();
				}
			},
			minLength: 3,
			select: function (event, ui) {
				_loadDictionariesBySettlementId(ui.item.id, false);
				_setFocusToStreetTextBox();
			},
			open: function () {
			},
			close: function () {
			}
		});

		var initializedMode = _isSettlementInputModeSaved() ? _settlementInputModeField.val().toLowerCase() : "";
		var isFirstInit = !initializedMode;


		// показываем нужные панельки и прячем ненужные
		_setSettlementInputMode(_getSettlementInputMode());

		if (isFirstInit) {
			if (!_isQuickSettlementInputModeAvailable()) {
				_showComplexSettlementInput();
				_activeMode = selectMode;
			} else {
				_showQuickSettlementInput();
				_activeMode = !_this.settlementId ? quickMode : selectMode;
			}
		} else {
			switch (initializedMode) {
				case quickMode:
					_showQuickSettlementInput();
					break;
				case selectMode:
					_showComplexSettlementInput();
					break;
				case customMode:
					_showComplexSettlementInput();
					_showCustomSettlementInput();
					break;
				default:
			}
		}
	}

	function _initStreet() {
		_streetTextBox.blur(function () {
			_updateFullAddress();
		});

		_streetTypeSelector.change(function (e, isFake) {
			if (!isFake && !_updating)
				_updateFullAddress();
			return false;
		});

		_streetTextBox.autocomplete({
			source: function (request, response) {
				if (_this.isDictionaryInitialized) {
					var query = {
						postIndex: _getPostIndex(),
						searchValue: request.term
					};

					var settlementId = _getSelectedSettlementId();
					var districtId = _getSelectedDistrictId();
					var regionId = _getSelectedRegionId();
					if (!_isEmptyOrDelimiterOrOther(settlementId))
						query.settlementId = settlementId;
					else {
						if (!_isEmptyOrDelimiter(districtId))
							query.districtId = districtId;
						else if (!_isEmptyOrDelimiter(regionId))
							query.regionId = regionId;
						else {
							response([]);
							return;
						}

						if (_getSettlementName() === null || _isEmptyOrDelimiter(_getSelectedSettlementTypeId())) {
							response([]);
							return;
						}

						query.settlementName = _getSettlementName();
						query.settlementTypeId = _getSelectedSettlementTypeId();
					}

					jQuery.itcJsonp({
						url: _this.host + "/v1/postaddress/autocomplete/streets",
						data: query,
						success: function (data) {
							response($.map(data, function (item) {
								return {
									label: item.text,
									value: item.name,
									type: item.type,
									typename: item.typename,
									postIndex: item.postIndex
								};
							}));
						}
					});
				} else {
					response();
				}
			},
			minLength: 3,
			select: function (event, ui) {
				if (_getPostIndex() == null) {
					_setPostIndex(ui.item.postIndex);
				}
				_setStreet(ui.item.value);
				_selectStreetTypeById(ui.item.type);
				_updateFullAddress();
				_setFocusToHouse();
			},
			open: function () {
			},
			close: function () {
			}
		});
	};

	function _initHouse() {
		_houseTextBox.change(function () { _updateFullAddress(); });
		$(_houseSwitch).click(function () {
			$(_housePanel).show();
			$(_estatePanel).hide();
			_isEstate = false;
			_isEstateHiddenField.val(false);
			_updateFullAddress();
			return false;
		});
		$(_estateSwitch).click(function () {
			$(_estatePanel).show();
			$(_housePanel).hide();
			_isEstate = true;
			_isEstateHiddenField.val(true);
			_updateFullAddress();
			return false;
		});
	};

	function _initUnit() {
		_unitTextBox.change(function () { _updateFullAddress(); });
	};

	function _initBuilding() {
		_buildingTextBox.change(function () { _updateFullAddress(); });
	};

	function _initFlat() {
		_flatTextBox.change(function () { _updateFullAddress(); });
		$(_flatSwitch).click(function () {
			$(_flatPanel).show();
			$(_officePanel).hide();
			_isOffice = false;
			_isOfficeHiddenField.val(false);
			_updateFullAddress();
			return false;
		});
		$(_officeSwitch).click(function () {
			$(_officePanel).show();
			$(_flatPanel).hide();
			_isOffice = true;
			_isOfficeHiddenField.val(true);
			_updateFullAddress();
			return false;
		});
	};

	function _initLine(lineTextBox) {
		lineTextBox.change(function () { _updateFullAddress(); });
	};

	function _rebindAll(data, inputInSimpleSettelment) {
		_fillCountriesList(data.countries);
		_selectCountryById(data.selectedCountry.value);
		_setIsAddressStructured(data.selectedCountry.isAddressStructured);

		_fillRegionsList(data.regions);
		_selectRegionById(data.selectedRegion);

		_fillDistrictsList(data.districts);
		_selectDistrictById(data.selectedDistrict);

		_fillSettlementsList(data.settlements);
		_selectSettlementById(data.selectedSettlement);

		if (typeof data.street !== "undefined" && data.street !== null) {
			_setStreet(data.street);
			_selectStreetTypeById(data.selectedStreetType);
		}

		if (!_initialized) {
			_initialized = true;

			_selectSettlementById(_this.settlementId);

			_setCustomSettlementName(_this.settlementName);

			if (data.settlementTypes != null) {
				_fillSelect(_settlementTypeSelector, data.settlementTypes);
				_selectSettelmentTypeById(_this.settlementTypeId);
			}

			if (data.streetTypes != null) {
				_fillSelect(_streetTypeSelector, data.streetTypes);
				_selectStreetTypeById(_this.streetTypeId);
			}
		}

		if (inputInSimpleSettelment ||
			(typeof data.selectedPostIndex !== "undefined" && data.selectedPostIndex !== null)) {
			_setPostIndex(data.selectedPostIndex);
		}
		_regionNameForFullAdress = data.selectedRegionName;
		_districtNameForFullAdress = data.selectedDistrictName;
		_selectSettelmentTypeById(
			_isEmpty(data.selectedSettlementTypeId) ? _this.settlementTypeId : data.selectedSettlementTypeId);

		if (_activeMode == customMode) {
			_setCustomSettlementName(data.selectedSettlementName ? data.selectedSettlementName : _this.settlementName);
		}

		if (!inputInSimpleSettelment || _getTextForQuickInput() != null) {
			_quickSettlementInputTextBox.val(_getTextForQuickInput());
		}

		var settlementId = _getSelectedSettlementId();
		if (inputInSimpleSettelment) {
			_setSettlementInputMode(_isEmpty(settlementId) ? quickMode : selectMode);
		}
		else {
			_setSettlementInputMode(_isOther(settlementId) ? customMode : selectMode);
		}

		_updateFullAddress();

		if (_this.onDictionariesUpdated != null)
			_this.onDictionariesUpdated();
	};

	function _getDict(url, isInitalization, params) {
		if (!_updating && (isInitalization || _this.isDictionaryInitialized)) {
			if (typeof (_this.dictionaryBeforeLoadCallback) == 'function') { _this.dictionaryBeforeLoadCallback(); }

			_updating = true;
			jQuery.itcJsonp({
				url: _this.host + url,
				data: params,
				success: function (data) {
					_rebindAll(data, false);
					_updating = false;

					if (isInitalization)
						_this.isDictionaryInitialized = true;

					if (typeof (_this.dictionaryLoadCallback) == 'function') { _this.dictionaryLoadCallback(); }
				}
			});
		}
	};

	function _loadDictionaries(isInitalization) {
		_getDict("/v1/postaddress/getdictionaries", isInitalization, null);
	};

	function _loadDictionariesBy(by, val, isInitalization) {
		if (val != "")
			_getDict("/v1/postaddress/getdictionaries/" + by + "/" + val, isInitalization, null);
	};

	function _loadDictionariesByPostIndex(postIndex) {
		if (postIndex != "") {
			var params = {
				"countryId": _getSelectedCountryId(),
				"postIndex": postIndex
			}
			_getDict("/v1/postaddress/getdictionaries/bypostindex/for-country/", false, params);
		}
	};

	function _loadDictionariesByCountryId(countryId, isInitalization) {
		_loadDictionariesBy("bycountry", countryId, isInitalization);
	};

	function _loadDictionariesByRegionId(regionId, isInitalization) {
		_loadDictionariesBy("byregion", regionId, isInitalization);
	};

	function _loadDictionariesByDistrictId(districtId, isInitalization) {
		_loadDictionariesBy("bydistrict", districtId, isInitalization);
	};

	function _loadDictionariesBySettlementId(settlementId, isInitalization) {
		_loadDictionariesBy("bysettlement", settlementId, isInitalization);
	};

	function _loadDictionariesBySettlementIdAndPostIndex(settlementId, postIndex) {
		if (settlementId != "" || postIndex != "") {
			var params = {
				"countryId": _getSelectedCountryId(),
				"settlementId": settlementId,
				"postIndex": postIndex
			}
			_getDict("/v1/postaddress/getdictionaries/bysettlementandpostindex/for-country/", false, params);
		}
	};

	function _tryLoadDictionariesBySettlementName(settlementName) {
		if (!_updating) {
			_updating = true;
			jQuery.itcJsonp({
				url: _this.host + "/v1/postaddress/getdictionaries/trybysettlementname/for-country/",
				data: { "countryId": _getSelectedCountryId(), "settlementName": settlementName },
				success: function (data) {
					_rebindAll(data, true);
					_updating = false;
				}
			});
		}
	};

	function _updateFullAddress() {
		var addressParts = new Array();

		var postIndex = _getPostIndex();
		if (postIndex != null) {
			addressParts.push(postIndex);
		}

		var countryName = _getSelectedCountryName();
		if (countryName != null) {
			addressParts.push(countryName);
		}

		if (_regionNameForFullAdress != null && _regionNameForFullAdress !== "") {
			addressParts.push(_regionNameForFullAdress);
		}

		if (_districtNameForFullAdress != null && _districtNameForFullAdress !== "") {
			addressParts.push(_districtNameForFullAdress);
		}

		var settelmentName = _getSettlementName();
		var settelmentTypeName = _getSelectedSettelmentTypeName();
		if (settelmentName != null) {
			addressParts.push((settelmentTypeName != null ? settelmentTypeName + " " : "") + settelmentName);
		}

		if (_getIsAddressStructured()) {
			var streetName = _getStreet();
			var streetType = _getStreetTypeName();
			if (streetName != null && streetType != null) {
				addressParts.push((streetType == "другой тип" ? "" : streetType + " ") + streetName);
			}

			var house = _getHouse();
			if (house != null) {
				var isEstateValue = _getIsEstateValue() == "true";
				addressParts.push((isEstateValue ? "вл. " : "д. ") + house);
			}

			var unit = _getUnit();
			if (unit != null) {
				addressParts.push("стр. " + unit);
			}

			var building = _getBuilding();
			if (building != null) {
				addressParts.push("корп. " + building);
			}

			var flat = _getFlat();
			if (flat != null) {
				addressParts.push("кв. " + flat);
			}
		}
		else {
			var line1 = _getLine1();
			if (line1 != null) {
				addressParts.push(line1);
			}

			var line2 = _getLine2();
			if (line2 != null) {
				addressParts.push(line2);
			}
		}
		_fullAddressLabel.text(addressParts.join(", "));
	}

	///////////////////
	// Public methods
	///////////////////
	this.init = function () {
		_initialized = false;

		_initControls();
		_initPostIndex();
		_initCountry();
		_initRegion();
		_initDistrict();
		_initSettlement();
		_initStreet();
		_initHouse();
		_initFlat();
		_initUnit();
		_initBuilding();
		_initFlat();
		_initLine(_line1TextBox);
		_initLine(_line2TextBox);

		if (!_isEmptyOrDelimiterOrOther(_this.settlementId)) {
			_loadDictionariesBySettlementId(_this.settlementId, true);
			this.onDictionariesUpdated = function () {
				_settlementSelector.val(_this.settlementId);
				_setCustomSettlementName("");
				_quickSettlementInputTextBox.val(_getTextForQuickInput());
				this.onDictionariesUpdated = null;
			}
		}
		else if (!_isEmptyOrDelimiter(_this.districtId))
			_loadDictionariesByDistrictId(_this.districtId, true);
		else if (!_isEmptyOrDelimiter(_this.regionId))
			_loadDictionariesByRegionId(_this.regionId, true);
		else if (!_isEmptyOrDelimiter(_this.countryId))
			_loadDictionariesByCountryId(_this.countryId, true);
		else
			_loadDictionaries(true);
	};

	this.bindPostIndexInput = function (postIndexInput) {
		_postIndexInput = $(postIndexInput);
	};

	this.bindGetPostIndexFunction = function (getPostIndex) {
		_getPostIndex = $(getPostIndex);
	};

	this.bindCountry = function (countrySelector) {
		_regionSelector = $(countrySelector);
	};

	this.bindRegion = function (regionSelector) {
		_regionSelector = $(regionSelector);
	};

	this.bindDistrict = function (districtSelector) {
		_districtSelector = $(districtSelector);
	};

	this.bindSettlement = function (settlementSelectorPanel, settlementSelector, settlementTextBoxPanel, customSettlementTextBox, settlementTypeSelector, settlementEnterModeSwitch) {
		_settlementSelectorPanel = $(settlementSelectorPanel);
		_settlementSelector = $(settlementSelector);
		_settlementTextBoxPanel = $(settlementTextBoxPanel);
		_customSettlementTextBox = $(customSettlementTextBox);
		_settlementTypeSelector = $(settlementTypeSelector);
		_switchSettlementInputModeToSelector = $(settlementEnterModeSwitch);
	};

	this.bindStreet = function (streetTextBox, streetTypeSelector) {
		_streetTextBox = $(streetTextBox);
		_streetTypeSelector = $(streetTypeSelector);
	};

	this.bindHouse = function (houseTextBox) {
		_houseTextBox = $(houseTextBox);
	};

	this.onDictionariesUpdated = null;

	// Уведомление об изменении почтового индекса – должен вызываться, чтобы уведомить JavaScript почтового адреса об изменении почтового индекса,
	// если не зарегистрировано поле почтового индекса или его значение изменяется программно.
	this.onPostIndexChanged = function (postIndex) {
		var selectedRegionId = _getSelectedRegionId();
		if (_getIsAddressStructured() && postIndex.toString().length === 6 && selectedRegionId != null && !_isEmptyOrDelimiterOrOther(selectedRegionId)) {
			_loadDictionariesByPostIndex(postIndex);
		}
	};

	// Уведомление об изменении страны – должен вызываться, чтобы уведомить JavaScript почтового адреса об изменении страны,
	// если не зарегистрирован select выбора страны или его значение изменяется программно.
	this.onCountryChanged = function () {
		_quickSettlementInputTextBox.val(null);
		_postIndexInput.val(null);
		if (!_isEmptyOrDelimiter(_getSelectedCountryId())) {
			_loadDictionariesByCountryId(_getSelectedCountryId(), false);
		} else {
			_loadDictionaries(false);
		}
	};

	// Уведомление об изменении региона – должен вызываться, чтобы уведомить JavaScript почтового адреса об изменении региона,
	// если не зарегистрирован select выбора региона или его значение изменяется программно.
	this.onRegionChanged = function () {
		_quickSettlementInputTextBox.val(null);
		if (!_isEmptyOrDelimiter(_getSelectedRegionId())) {
			_loadDictionariesByRegionId(_getSelectedRegionId(), false);
		} else {
			_loadDictionaries(false);
		}
	};

	// Уведомление об изменении района – должен вызываться, чтобы уведомить JavaScript почтового адреса об изменении района,
	// если не зарегистрирован select выбора района или его значение изменяется программно.
	this.onDistrictChanged = function () {
		_quickSettlementInputTextBox.val(null);
		if (!_isEmptyOrDelimiter(_getSelectedDistrictId())) {
			_loadDictionariesByDistrictId(_getSelectedDistrictId(), false);
		} else {
			_loadDictionariesByRegionId(_getSelectedRegionId(), false);
		}
	};

	// Уведомление об изменении выбранного в списке населённого пункта – должен вызываться, чтобы уведомить JavaScript почтового адреса
	// об изменении населённого пункта, выбираемого из списка, если не зарегистрирован select выбора населённого пункта или его значение изменяется программно.
	this.onSettlementIdChanged = function () {
		var selectedSettlementId = _getSelectedSettlementId();

		if (!_isEmptyOrDelimiterOrOther(selectedSettlementId)) {
			_quickSettlementInputTextBox.val(_getSelectedSettlementName());
			_loadDictionariesBySettlementId(selectedSettlementId, false);
		}
		else {
			_quickSettlementInputTextBox.val(null);
			if (_isOther(selectedSettlementId)) {
				_setSettlementInputMode(customMode);
			}
		}
	};

	this.onSimpleSettlementChanged = function () {
		var simpleSettlement = $.trim(_quickSettlementInputTextBox.val());

		if (simpleSettlement == "") {
			_setSettlementInputMode(quickMode);
			_updateFullAddress();
		}
		else {
			var postIndex;
			var settelmentName;
			if (simpleSettlement.indexOf(",") != -1) {
				var items = simpleSettlement.split(",");
				postIndex = $.trim(items[0]);
				settelmentName = $.trim(items[1]);
			} else {
				settelmentName = postIndex = simpleSettlement;
			}

			var postIndexRegEx = /^[1-9][0-9]{5}$/;
			if (_getIsAddressStructured() && postIndexRegEx.test(postIndex)) {
				_loadDictionariesByPostIndex(postIndex);
			} else {
				_tryLoadDictionariesBySettlementName(settelmentName);
			}
		}
	};
}

var PostAddress = new PostAddressClass();