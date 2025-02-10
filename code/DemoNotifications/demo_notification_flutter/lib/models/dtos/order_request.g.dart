// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'order_request.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

OrderRequest _$OrderRequestFromJson(Map<String, dynamic> json) => OrderRequest(
      OrderContent: json['OrderContent'] as String,
      deviceToken: json['deviceToken'] as String,
    );

Map<String, dynamic> _$OrderRequestToJson(OrderRequest instance) =>
    <String, dynamic>{
      'OrderContent': instance.OrderContent,
      'deviceToken': instance.deviceToken,
    };
